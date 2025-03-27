using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Final_Project_APW.Controllers;
using Final_Project_APW.Domain.Interfaces;
using Final_Project_APW.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ClientsControllerTests
{
    private readonly Mock<IClientService> _clientServiceMock;
    private readonly ClientsController _controller;

    public ClientsControllerTests()
    {
        _clientServiceMock = new Mock<IClientService>();
        _controller = new ClientsController(_clientServiceMock.Object);
    }

    [Fact]
    public async Task GetClientsAsync_ReturnsOkResult_WithClients() //Prueba que la API retorna clientes correctamente.
    {
        // Arrange
        var mockClients = new List<Client>
        {
            new Client
            {
                Id = Guid.NewGuid(),
                FirstName = "John",
                SecondName = "A.",
                LastName = "Doe"
            }
        };
        _clientServiceMock.Setup(s => s.GetClientsAsync()).ReturnsAsync(mockClients);

        // Act
        var result = await _controller.GetClientsAsync();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnedClients = Assert.IsType<List<Client>>(okResult.Value);
        Assert.Single(returnedClients);
    }

    [Fact]
    public async Task GetClientsAsync_ReturnsNotFound_WhenNoClients()//Prueba el caso cuando no hay clientes.
    {
        // Arrange
        _clientServiceMock.Setup(s => s.GetClientsAsync()).ReturnsAsync(new List<Client>());

        // Act
        var result = await _controller.GetClientsAsync();

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public async Task CreateClientAsync_ReturnsOk_WhenClientCreated() //Prueba la creación de un cliente.
    {
        // Arrange
        var newClient = new Client
        {
            Id = Guid.NewGuid(),
            FirstName = "Jane",
            SecondName = "B.",
            LastName = "Doe"
        };
        _clientServiceMock.Setup(s => s.CreateClientAsync(It.IsAny<Client>())).ReturnsAsync(newClient);

        // Act
        var result = await _controller.CreateClientAsync(newClient);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedClient = Assert.IsType<Client>(okResult.Value);
        Assert.Equal("Jane", returnedClient.FirstName);
        Assert.Equal("B.", returnedClient.SecondName);
        Assert.Equal("Doe", returnedClient.LastName);
    }

    [Fact]
    public async Task GetClientByIdAsync_ReturnsNotFound_WhenClientDoesNotExist() // Prueba cuando el cliente no existe.
    {
        // Arrange
        _clientServiceMock.Setup(s => s.GetClientByIdAsync(It.IsAny<Guid>())).ReturnsAsync((Client)null);

        // Act
        var result = await _controller.GetClientByIdAsync(Guid.NewGuid());

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }



}
