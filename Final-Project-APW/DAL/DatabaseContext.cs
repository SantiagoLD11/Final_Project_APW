using Microsoft.EntityFrameworkCore;
using Final_Project_APW.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_APW.DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasIndex(c => c.Name).IsUnique(); //Esto es un índice para evitar nombres duplicados de productos
            modelBuilder.Entity<Category>().HasIndex(c => c.Name).IsUnique(); 
            modelBuilder.Entity<Estate>().HasIndex(c => c.Name).IsUnique(); 

        }

        public DbSet<Product> Products { get; set; } 
        public DbSet<Estate> Estates { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
