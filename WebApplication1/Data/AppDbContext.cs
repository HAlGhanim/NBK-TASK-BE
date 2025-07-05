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
                new Customer { Number = 4, Name = "Diana", DateOfBirth = new DateOnly(1995, 8, 10), Gender = "F" },
                new Customer { Number = 5, Name = "Edward", DateOfBirth = new DateOnly(1988, 3, 5), Gender = "M" },
                new Customer { Number = 6, Name = "Fiona", DateOfBirth = new DateOnly(1992, 7, 19), Gender = "F" },
                new Customer { Number = 7, Name = "George", DateOfBirth = new DateOnly(1983, 10, 23), Gender = "M" },
                new Customer { Number = 8, Name = "Hannah", DateOfBirth = new DateOnly(1999, 11, 11), Gender = "F" },
                new Customer { Number = 9, Name = "Ian", DateOfBirth = new DateOnly(1991, 2, 17), Gender = "M" },
                new Customer { Number = 10, Name = "Julia", DateOfBirth = new DateOnly(1996, 6, 6), Gender = "F" },
                new Customer { Number = 11, Name = "Kevin", DateOfBirth = new DateOnly(1987, 4, 13), Gender = "M" },
                new Customer { Number = 12, Name = "Laura", DateOfBirth = new DateOnly(1993, 9, 2), Gender = "F" },
                new Customer { Number = 13, Name = "Mike", DateOfBirth = new DateOnly(1989, 12, 24), Gender = "M" },
                new Customer { Number = 14, Name = "Nina", DateOfBirth = new DateOnly(1997, 1, 30), Gender = "F" },
                new Customer { Number = 15, Name = "Oscar", DateOfBirth = new DateOnly(1982, 8, 18), Gender = "M" },
                new Customer { Number = 16, Name = "Paula", DateOfBirth = new DateOnly(1994, 5, 9), Gender = "F" },
                new Customer { Number = 17, Name = "Quentin", DateOfBirth = new DateOnly(1990, 10, 4), Gender = "M" },
                new Customer { Number = 18, Name = "Rachel", DateOfBirth = new DateOnly(1998, 3, 22), Gender = "F" },
                new Customer { Number = 19, Name = "Steve", DateOfBirth = new DateOnly(1986, 6, 14), Gender = "M" },
                new Customer { Number = 20, Name = "Tina", DateOfBirth = new DateOnly(1995, 12, 1), Gender = "F" }
            );
        }
    }
}
