using Final_Project_APW.DAL;
using Final_Project_APW.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Final_Project_APW.DAL.Entities;

namespace Final_Project_APW.Domain.Services
{
    public class OrderService : IOrderService
    {

        private readonly DatabaseContext _context;

        public OrderService(DatabaseContext context)
        {
            _context = context;
        }
        private static int _lastOrderNumber = 0; // Variable estática para almacenar el último número de pedido

        int NumeroOrder = 0;

        public async Task<Order> CreateOrderAsync(Order order)
        {
            try
            {
           
                // Asignar el siguiente número de pedido
          
                Guid OrdenNueva = _context.OrderEstates.Where(e => e.NameEsateOrder == "En espera").Select(e => e.Id).FirstOrDefault();

                order.Estate_OrderId= OrdenNueva;

                 NumeroOrder = (_context.Orders.Max(order => order.NumOrder)+1);

                order.NumOrder= NumeroOrder;
                order.Id = Guid.NewGuid();
                order.CreatedDate = DateTime.Now;
                _context.Orders.Add(order);
                await _context.SaveChangesAsync(); //Aquí ya estoy yendo a la BD para hacer el INSERT en la tabla 

                return order;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message); //Coallesences Notation --> ??
            }
        }
    }
}