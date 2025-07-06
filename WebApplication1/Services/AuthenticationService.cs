using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication1.Data;
using WebApplication1.Data.Models;
using WebApplication1.DTOs;
using WebApplication1.Interfaces;

namespace WebApplication1.Services
{

    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;

        public AuthService(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public string HashPassword(string password) =>
            BCrypt.Net.BCrypt.HashPassword(password);

        public bool VerifyPassword(string password, string hashed) =>
            BCrypt.Net.BCrypt.Verify(password, hashed);

        public string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "NBK-TASK-BE",
                audience: "NBK-TASK-FE",
                claims: claims,
                expires: DateTime.Now.AddHours(24),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<string?> Register(AuthenticationDTO request)
        {
            if (await _context.Users.AnyAsync(u => u.Username == request.Username))
                return null;

            var user = new User
            {
                Username = request.Username,
                Password = HashPassword(request.Password)
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return "User registered successfully.";
        }

        public async Task<string?> Login(AuthenticationDTO request)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Username == request.Username);
            if (user == null || !VerifyPassword(request.Password, user.Password))
                return null;

            return GenerateJwtToken(user);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }
    }
}