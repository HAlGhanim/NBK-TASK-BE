using WebApplication1.Data.Models;
using WebApplication1.DTOs;

namespace WebApplication1.Interfaces
{
    public interface IAuthService
    {
        Task<string?> Register(AuthenticationDTO request);
        Task<string?> Login(AuthenticationDTO request);
        Task<List<User>> GetAllUsers();
        string HashPassword(string password);
        bool VerifyPassword(string password, string hashed);
        string GenerateJwtToken(User user);
    }
}
