using WebApplication1.DTOs;

namespace WebApplication1.Interfaces
{
    public interface ICustomerService
    {
        Task<List<CustomerDTO>> GetAll();
        Task<CustomerDTO?> GetByNumber(int number);
        Task<CustomerDTO> Create(CreateCustomerDTO dto);
        Task<CustomerDTO?> Update(int number, UpdateCustomerDTO dto);
        Task<string?> Delete(int number);
    }
}
