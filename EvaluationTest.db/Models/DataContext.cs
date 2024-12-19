using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvaluationTest.db.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<OrderProductMapping> OrderProductMappings { get; set; }    

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define the precision and scale for the 'product_price' column
            modelBuilder.Entity<Product>()
                .Property(p => p.product_price)
                .HasColumnType("decimal(10,2)");  // Decimal(10, 2)
        }

    }
}
