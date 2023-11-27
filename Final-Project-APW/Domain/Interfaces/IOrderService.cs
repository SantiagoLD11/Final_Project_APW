using System.Diagnostics.Metrics;
using Final_Project_APW.DAL.Entities;

namespace Final_Project_APW.Domain.Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(Order order);
        Task<IEnumerable<Order>> GetOrderAsync();
    }

}
