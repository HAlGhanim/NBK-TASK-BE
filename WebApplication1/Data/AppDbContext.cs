using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Models;

namespace WebApplication1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>().HasData(
                new Customer { Number = 1, Name = "Alice", DateOfBirth = new DateOnly(1990, 1, 1), Gender = "F" },
                new Customer { Number = 2, Name = "Bob", DateOfBirth = new DateOnly(1985, 5, 20), Gender = "M" },
                new Customer { Number = 3, Name = "Charlie", DateOfBirth = new DateOnly(2000, 12, 15), Gender = "M" },
                new Customer { Number = 4, Name = "Diana", DateOfBirth = new DateOnly(1995, 8, 10), Gender = "F" }
            );
        }
    }
}
