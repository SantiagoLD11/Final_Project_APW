using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Final_Project_APW.Controllers;
using Final_Project_APW.Domain.Interfaces;
using Final_Project_APW.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class OrdersControllerTests
{
    private readonly Mock<IOrderService> _orderServiceMock;
    private readonly OrdersController _controller;

    public OrdersControllerTests()
    {
        _orderServiceMock = new Mock<IOrderService>();
        _controller = new OrdersController(_orderServiceMock.Object);
    }

    [Fact]
    public async Task CreateOrderAsync_ReturnsBadRequest_WhenOrderIsNull()
    {
        // Act
        var result = await _controller.CreateOrderAsync(null);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public async Task CreateOrderAsync_ReturnsConflict_WhenOrderAlreadyExists()
    {
        // Arrange
        var existingOrder = new Order { NumOrder = 12345 };
        _orderServiceMock.Setup(s => s.CreateOrderAsync(It.IsAny<Order>()))
                         .ThrowsAsync(new Exception("La orden con este número ya existe"));

        // Act
        var result = await _controller.CreateOrderAsync(existingOrder);

        // Assert
        var conflictResult = Assert.IsType<ConflictObjectResult>(result);
        Assert.Equal("La orden con este número ya existe", conflictResult.Value);
    }

    [Fact]
    public async Task GetOrderAsync_ReturnsOrdersInCorrectOrder()
    {
        // Arrange
        var mockOrders = new List<Order>
        {
            new Order { NumOrder = 1001, FechaDespacho = DateTime.UtcNow.AddDays(-2) },
            new Order { NumOrder = 1002, FechaDespacho = DateTime.UtcNow.AddDays(-1) }
        };
        _orderServiceMock.Setup(s => s.GetOrderAsync()).ReturnsAsync(mockOrders);

        // Act
        var result = await _controller.GetOrderAsync();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnedOrders = Assert.IsType<List<Order>>(okResult.Value);
        Assert.Equal(mockOrders, returnedOrders);
    }

    [Fact]
    public async Task CreateOrderAsync_ReturnsOk_WithCorrectMessage()
    {
        // Arrange
        var newOrder = new Order { NumOrder = 2001, Observation = "Pedido urgente" };
        _orderServiceMock.Setup(s => s.CreateOrderAsync(It.IsAny<Order>())).ReturnsAsync(newOrder);

        // Act
        var result = await _controller.CreateOrderAsync(newOrder);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal("Su pedido se encuentra en espera", okResult.Value);
    }
    [Fact]
    public async Task CreateOrderAsync_ReturnsBadRequest_WhenNumOrderIsInvalid()
    {
        // Arrange
        var invalidOrder = new Order
        {
            ClientId = Guid.NewGuid(),
            NumOrder = -5, // ❌ Número de orden inválido (debe ser positivo)
            Observation = "Test Order",
            FechaDespacho = DateTime.UtcNow
        };

        _orderServiceMock.Setup(s => s.CreateOrderAsync(It.IsAny<Order>()))
                         .ReturnsAsync(invalidOrder);

        // Act
        var result = await _controller.CreateOrderAsync(invalidOrder);

        // Assert
        Assert.IsType<BadRequestResult>(result); // ❌ Esto fallará porque el controlador no devuelve BadRequest
    }

}
