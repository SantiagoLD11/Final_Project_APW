using System.Diagnostics.Metrics;
using System.Xml.Linq;
using Final_Project_APW.DAL.Entities;
using Microsoft.EntityFrameworkCore;

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
            await PopulateClientsAsync();
            await PopulateTypesDocsAsync();

            await PopulateEstatesAsync();
            await PopulateCategoriesAsync();

            await _context.SaveChangesAsync(); //Esta línea me guarda los datos en BD
        }

        #region Private Methos
        private async Task PopulateCategoriesAsync()
        {
            //El método Any() me indica si la tabla Hotels tiene al menos un registro
            //El método Any negado (!) me indica que no hay absolutamente nada en la tabla Hotels.

            if (!_context.Categories.Any())
            {

                //Aquí creo otro nuevo producto
                _context.Categories.Add(new Category
                {
                    CreatedDate = DateTime.Now,
                    Name = "Comidas Rapidas",
                });

                _context.Categories.Add(new Category
                {
                    CreatedDate = DateTime.Now,
                    Name = "Ensaladas",
                });

                _context.Categories.Add(new Category
                {
                    CreatedDate = DateTime.Now,
                    Name = "Comidas Tipo Buffet",
                });
            }
        }
        private async Task PopulateEstatesAsync()
        {
            //El método Any() me indica si la tabla Hotels tiene al menos un registro
            //El método Any negado (!) me indica que no hay absolutamente nada en la tabla Hotels.

            if (!_context.Estates.Any())
            {

                //Aquí creo otro nuevo producto
                _context.Estates.Add(new Estate
                {
                    CreatedDate = DateTime.Now,
                    Name = "Creado",
                });

                _context.Estates.Add(new Estate
                {
                    CreatedDate = DateTime.Now,
                    Name = "Activo",
                });

                _context.Estates.Add(new Estate
                {
                    CreatedDate = DateTime.Now,
                    Name = "Inactivo",
                });
            }
        }
        private async Task PopulateTypesDocsAsync()
        {
            //El método Any() me indica si la tabla Hotels tiene al menos un registro
            //El método Any negado (!) me indica que no hay absolutamente nada en la tabla Hotels.

            if (!_context.TypesDocs.Any())
            {

                //Aquí creo otro nuevo producto
                 _context.TypesDocs.Add(new TypeDocument
                {
                    CreatedDate = DateTime.Now,
                    Name = "CC",
                });

                _context.TypesDocs.Add(new TypeDocument
                {
                    CreatedDate = DateTime.Now,
                    Name = "TI",
                });

                _context.TypesDocs.Add(new TypeDocument
                {
                    CreatedDate = DateTime.Now,
                    Name = "CD",
                });

                _context.TypesDocs.Add(new TypeDocument
                {
                    CreatedDate = DateTime.Now,
                    Name = "CE",
                });
            }
        }
        private async Task PopulateProductsAsync()
        {
            //El método Any() me indica si la tabla Hotels tiene al menos un registro
            //El método Any negado (!) me indica que no hay absolutamente nada en la tabla Hotels.

            if (!_context.Products.Any())
            {
                var category = await _context.Categories.FirstOrDefaultAsync();

                var estate = await _context.Estates.Skip(1).FirstOrDefaultAsync();
                //Aquí creo otro nuevo producto
                _context.Products.Add(new Product
                {
                    CreatedDate = DateTime.Now,
                    Name = "Salchipapas de la Casa",
                    Description = "Deliciosa combinación de papas y salchichas con nuestra exclusiva salsa",
                    Price = 10000,
                    Preparation_time_min = 15,
                    IdEstate = estate.Id,
                    IdCategory = category.Id
                });

                category = await _context.Categories.Skip(1).FirstOrDefaultAsync();

                //Aquí creo otro nuevo producto
                _context.Products.Add(new Product
                {
                    CreatedDate = DateTime.Now,
                    Name = "'Batido de Frutas Tropicales",
                    Description = "Refrescante batido con mango, piña y plátano",
                    Price = 19900,
                    Preparation_time_min = 15,
                    IdEstate = estate.Id,
                    IdCategory = category.Id
                });
                category = await _context.Categories.FirstOrDefaultAsync();
                //Aquí creo otro nuevo producto
                _context.Products.Add(new Product
                {
                    CreatedDate = DateTime.Now,
                    Name = "Tacos de Carne Asada",
                    Description = "Tacos con carne asada, cebolla y cilantro",
                    Price = 23000,
                    Preparation_time_min = 15,
                    IdEstate = estate.Id,
                    IdCategory = category.Id
                });
                //Aquí creo otro nuevo producto
                _context.Products.Add(new Product
                {
                    CreatedDate = DateTime.Now,
                    Name = "Ensalada César",
                    Description = "Ensalada fresca con pollo a la parrilla y aderezo césar",
                    Price = 8000,
                    Preparation_time_min = 10,
                    IdEstate = estate.Id,
                    IdCategory = category.Id
                });

                //Aquí creo otro nuevo producto
                _context.Products.Add(new Product
                {
                    CreatedDate = DateTime.Now,
                    Name = "Hamburguesa Clásica",
                    Description = "Jugosa hamburguesa con lechuga, tomate y queso cheddar",
                    Price = 18000,
                    Preparation_time_min = 15,
                    IdEstate = estate.Id,
                    IdCategory = category.Id
                });
                estate = await _context.Estates.Skip(2).FirstOrDefaultAsync();
                //Aquí creo otro nuevo producto
                _context.Products.Add(new Product
                {
                    CreatedDate = DateTime.Now,
                    Name = "Pizza Margarita",
                    Description = "Pizza con salsa de tomate, mozzarella fresca y albahaca",
                    Price = 35000,
                    Preparation_time_min = 15,
                    IdEstate = estate.Id,
                    IdCategory = category.Id
                });


            }
        }

        private async Task PopulateClientsAsync()
        {
            //El método Any() me indica si la tabla Hotels tiene al menos un registro
            //El método Any negado (!) me indica que no hay absolutamente nada en la tabla Hotels.

            if (!_context.Clients.Any())
            {
                var tyDoc = await _context.Categories.FirstOrDefaultAsync();

                var estate = await _context.Estates.Skip(1).FirstOrDefaultAsync();

                //Aquí creo otro nuevo cliente
                _context.Clients.Add(new Client
                {
                    FirstName = "MARIA",
                    SecondName = "CAMILA",
                    LastName = "ALVAREZ",
                    Mail = "MCAC334@GMAIL.COM",
                    Phone =1326855,
                    NumDoc = 123456,
                    Birthday = new DateTime(2002, 4, 24),
                    EstateId= estate.Id,
                    TypeDocumentId= tyDoc.Id


                });
                //Aquí creo otro nuevo cliente
                _context.Clients.Add(new Client
                {
                    FirstName = "MAITE",
                    SecondName = "PAOLA",
                    LastName = "CRUZ",
                    Mail = "Maitecruz@gmail.com",
                    Phone = 563632555,
                    NumDoc = 789455,
                    Birthday = new DateTime(2005, 8, 16),
                    EstateId = estate.Id,
                    TypeDocumentId = tyDoc.Id

                });
                //Aquí creo otro nuevo cliente
                estate = await _context.Estates.Skip(2).FirstOrDefaultAsync();
                _context.Clients.Add(new Client
                {
                    FirstName = "SANTIAGO",
                    SecondName = "ANDRES",
                    LastName = "PEREZ",
                    Mail = "Santi343@GMAIL.COM",
                    Phone = 582364,
                    NumDoc = 15948623,
                    Birthday = new DateTime(2000, 12, 14),
                    EstateId = estate.Id,
                    TypeDocumentId = tyDoc.Id

                });

            }
        }
    }

    #endregion
}

