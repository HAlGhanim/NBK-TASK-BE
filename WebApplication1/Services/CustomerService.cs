using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Data.Models;
using WebApplication1.DTOs;
using WebApplication1.Interfaces;

namespace WebApplication1.Services
{

    public class CustomerService : ICustomerService
    {
        private readonly AppDbContext _context;

        public CustomerService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CustomerDTO>> GetAll()
        {
            return await _context.Customers
                .Select(c => new CustomerDTO
                {
                    Number = c.Number,
                    Name = c.Name,
                    DateOfBirth = c.DateOfBirth,
                    Gender = c.Gender
                })
                .ToListAsync();
        }

        public async Task<CustomerDTO?> GetByNumber(int number)
        {
            var customer = await _context.Customers.FindAsync(number);
            if (customer == null) return null;

            return new CustomerDTO
            {
                Number = customer.Number,
                Name = customer.Name,
                DateOfBirth = customer.DateOfBirth,
                Gender = customer.Gender
            };
        }

        public async Task<CustomerDTO> Create(CreateCustomerDTO dto)
        {
            var customer = new Customer
            {
                Name = dto.Name,
                DateOfBirth = dto.DateOfBirth,
                Gender = dto.Gender
            };

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return new CustomerDTO
            {
                Number = customer.Number,
                Name = customer.Name,
                DateOfBirth = customer.DateOfBirth,
                Gender = customer.Gender
            };
        }

        public async Task<CustomerDTO?> Update(int number, UpdateCustomerDTO dto)
        {
            var customer = await _context.Customers.FindAsync(number);
            if (customer == null) return null;

            if (dto.Name != null)
                customer.Name = dto.Name;

            if (dto.DateOfBirth.HasValue)
                customer.DateOfBirth = dto.DateOfBirth.Value;

            if (!string.IsNullOrWhiteSpace(dto.Gender))
                customer.Gender = dto.Gender;

            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();

            return new CustomerDTO
            {
                Number = customer.Number,
                Name = customer.Name,
                DateOfBirth = customer.DateOfBirth,
                Gender = customer.Gender
            };
        }

        public async Task<string?> Delete(int number)
        {
            var customer = await _context.Customers.FindAsync(number);
            if (customer == null) return null;

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return $"Customer with number {number} has been deleted";
        }
    }
}
