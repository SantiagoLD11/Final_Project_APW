using Final_Project_APW.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Final_Project_APW.Domain.Interfaces;
using Final_Project_APW.Domain.Services;

namespace Final_Project_APW.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController :Controller
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet, ActionName("Get")]
        [Route("Get")] //Aquí concateno la URL inicial: URL = api/hotels/get
        public async Task<ActionResult<IEnumerable<Order>>> GetOrderAsync()
        {
            var orders = await _orderService.GetOrderAsync();

            if (orders == null || !orders.Any())
            {
                return NotFound(); //NotFound = 404 Http Status Code
            }

            return Ok(orders); //Ok = 200 Http Status Code
        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]

        public async Task<ActionResult> CreateOrderAsync(Order order)
        {
            try
            {

                var createdOrder = await _orderService.CreateOrderAsync(order);

                if (createdOrder == null)
                {
                    return NotFound(); //NotFound = 404 Http Status Code
                }

                return Ok(String.Format("Su pedido se encuentra en espera", createdOrder)); //Retorne un 200 y el objeto Country
            }
            catch (Exception ex)
            {
               

                return Conflict(ex.Message);
            }
        }
        
    }
}
