using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using Final_Project_APW.DAL;
using Final_Project_APW.DAL.Entities;
using Final_Project_APW.Domain.Interfaces;

namespace Final_Project_APW.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly DatabaseContext _context;

        public ProductService(DatabaseContext context)
        {
            _context = context;
        }

        //	Listar hoteles con sus respectivas habitaciones disponibles
        public async Task<IEnumerable<Product>> GetProductAsync()
        {
            var products = await _context.Products
                .ToListAsync();
            return products; //Retorne todos los datos que hay en la tabla Hotels.
        }

        //	Obtener hotel por ID con sus respectivas habitaciones disponibles
        public async Task<Product> GetProductByIdAsync(Guid id)
        {
            return await _context.Products.FirstOrDefaultAsync(h => h.Id == id);
        }



    }
}
