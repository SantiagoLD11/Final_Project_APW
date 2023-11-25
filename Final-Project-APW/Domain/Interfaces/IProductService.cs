using System.Diagnostics.Metrics;
using Final_Project_APW.DAL.Entities;

namespace Final_Project_APW.Domain.Interfaces
{
    public interface IProductService
    {
       
            Task<IEnumerable<Product>> GetProductAsync();
            Task<Product> GetProductByIdAsync(Guid id);

    
    }
}
