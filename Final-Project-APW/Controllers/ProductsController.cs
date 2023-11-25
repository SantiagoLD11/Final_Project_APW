using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using Final_Project_APW.DAL.Entities;
using Final_Project_APW.Domain.Interfaces;

namespace Final_Project_APW.Controllers
{
    [ApiController]
    [Route("api/[controller]")] //Esta es la primera parte de la URL de esta API: URL = api/hotels
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService hotelService)
        {
            _productService = hotelService;
        }

        [HttpGet, ActionName("Get")]
        [Route("Get")] // URL = api/hotels/get
        public async Task<ActionResult<IEnumerable<Product>>> GetProductAsync()
        {
            var products = await _productService.GetProductAsync(); //Se va a la capa de Domain para traerme la lista de productos

            //El método Any() significa si hay al menos un elemento.
            //El Método !Any() significa si no hay absoluta/ nada.
            if (products == null || !products.Any())
            {
                return NotFound(); 
            }

            return Ok(products); 
        }

        [HttpGet, ActionName("Get")]
        [Route("GetById/{id}")] //URL: api/hotels/get
        public async Task<ActionResult<Product>> GetProductByIdAsync(Guid id)
        {
            if (id == null) return BadRequest("Id es requerido!");

            var products = await _productService.GetProductByIdAsync(id);

            if (products == null) return NotFound(); // 404

            return Ok(products); // 200
        }

       
    }
}
