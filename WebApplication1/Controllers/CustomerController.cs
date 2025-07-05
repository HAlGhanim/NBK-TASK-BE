using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<CustomerDTO>>> GetAll()
        {
            var customers = await _customerService.GetAll();
            return Ok(customers);
        }

        [Authorize]
        [HttpGet("{number}")]
        public async Task<ActionResult<CustomerDTO>> GetByNumber(int number)
        {
            var customer = await _customerService.GetByNumber(number);
            if (customer == null)
                return NotFound($"Customer with number {number} not found.");

            return Ok(customer);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<CustomerDTO>> Create(CreateCustomerDTO dto)
        {
            var created = await _customerService.Create(dto);
            return CreatedAtAction(nameof(GetByNumber), new { number = created.Number }, created);
        }

        [Authorize]
        [HttpPut("{number}")]
        public async Task<ActionResult<CustomerDTO>> Update(int number, UpdateCustomerDTO dto)
        {
            var updated = await _customerService.Update(number, dto);
            if (updated == null)
                return NotFound($"Customer with number {number} not found.");

            return Ok(updated);
        }

        [Authorize]
        [HttpDelete("{number}")]
        public async Task<ActionResult<string>> Delete(int number)
        {
            var result = await _customerService.Delete(number);
            if (result == null)
                return NotFound($"Customer with number {number} not found.");

            return Ok(result);
        }
    }
}
