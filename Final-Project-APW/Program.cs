using Final_Project_APW.DAL;
using Final_Project_APW.Domain.Interfaces;
using Final_Project_APW.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//Esta l�nea me crea el contexto de la BD a la hora de correr esta API
//Funciones An�nimas (x => x....) Arrow Functions - Lambda Functions
builder.Services.AddDbContext<DatabaseContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

//Por cada nuevo servicio/interfaz que yo creo en mi API, debo agregar aqu� esa nueva dependencia
builder.Services.AddScoped<IProductService, ProductService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<DataBaseContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

//Por cada nuevo servicio/interfaz que yo creo en mi API, debo agregar aqu� esa nueva dependencia
builder.Services.AddScoped<IClientService, ClientService>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<SeederDB>();

var app = builder.Build();
SeederData();
void SeederData()
{
    IServiceScopeFactory? scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (IServiceScope? scope = scopedFactory.CreateScope())
    {
        SeederDB? service = scope.ServiceProvider.GetService<SeederDB>();
        service.SeederAsync().Wait();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
