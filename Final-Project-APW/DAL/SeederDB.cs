using System.Diagnostics.Metrics;
using Final_Project_APW.DAL.Entities;

namespace Final_Project_APW.DAL
{
    public class SeederDB
    {
        private readonly DatabaseContext _context;

        public SeederDB(DatabaseContext context)
        {
            _context = context;
        }

        public async Task SeederAsync()
        {

            await _context.Database.EnsureCreatedAsync();

            //A partir de aquí vamos a ir creando métodos que me sirvan para prepoblar mi BD
            await PopulateProductsAsync();

            await _context.SaveChangesAsync(); //Esta línea me guarda los datos en BD
        }

        #region Private Methos
        private async Task PopulateProductsAsync()
        {
            //El método Any() me indica si la tabla Hotels tiene al menos un registro
            //El método Any negado (!) me indica que no hay absolutamente nada en la tabla Hotels.

            if (!_context.Products.Any())
            {

                //Aquí creo otro nuevo producto
                _context.Products.Add(new Product
                {
                    CreatedDate = DateTime.Now,
                    Name = "Salchipapas de la Casa",
                    Description = "Deliciosa combinación de papas y salchichas con nuestra exclusiva salsa",
                    Price = 10000,
                    Preparation_time_min = 15,
                    IdEstate = 1,
                    IdCategory = 2
                });
                //Aquí creo otro nuevo producto
                _context.Products.Add(new Product
                {
                    CreatedDate = DateTime.Now,
                    Name = "'Batido de Frutas Tropicales",
                    Description = "Refrescante batido con mango, piña y plátano",
                    Price = 19900,
                    Preparation_time_min = 15,
                    IdEstate = 1,
                    IdCategory = 2
                });
                //Aquí creo otro nuevo producto
                _context.Products.Add(new Product
                {
                    CreatedDate = DateTime.Now,
                    Name = "Tacos de Carne Asada",
                    Description = "Tacos con carne asada, cebolla y cilantro",
                    Price = 23000,
                    Preparation_time_min = 15,
                    IdEstate = 1,
                    IdCategory = 3
                });
                //Aquí creo otro nuevo producto
                _context.Products.Add(new Product
                {
                    CreatedDate = DateTime.Now,
                    Name = "Ensalada César",
                    Description = "Ensalada fresca con pollo a la parrilla y aderezo césar",
                    Price = 8000,
                    Preparation_time_min = 10,
                    IdEstate = 1,
                    IdCategory = 4
                });

                //Aquí creo otro nuevo producto
                _context.Products.Add(new Product
                {
                    CreatedDate = DateTime.Now,
                    Name = "Hamburguesa Clásica",
                    Description = "Jugosa hamburguesa con lechuga, tomate y queso cheddar",
                    Price = 18000,
                    Preparation_time_min = 15,
                    IdEstate = 1,
                    IdCategory = 1
                });
                //Aquí creo otro nuevo producto
                _context.Products.Add(new Product
                {
                    CreatedDate = DateTime.Now,
                    Name = "Pizza Margarita",
                    Description = "Pizza con salsa de tomate, mozzarella fresca y albahaca",
                    Price = 35000,
                    Preparation_time_min = 15,
                    IdEstate = 1,
                    IdCategory = 1
                });


            }
        }
    }

    #endregion
}

