using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Final_Project_APW.DAL.Entities;

namespace Final_Project_APW.DAL
{
    public class DataBaseContext : DbContext
    {
        //Con este contructor me podré conectar a la BD, me brinda unas opciones de configuración que ya están definidas internamente
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TypeDocument>().HasIndex(c => c.Name).IsUnique(); //Esto es un índice para evitar nombres duplicados de hoteles
            modelBuilder.Entity<Client>().HasIndex(c => c.NumDoc).IsUnique();
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<TypeDocument> TypesDocs { get; set; }
        //Por cada nueva entidad que yo creo, debo crearle su DbSet

    }
}