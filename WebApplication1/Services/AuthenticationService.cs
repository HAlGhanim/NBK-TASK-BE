using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebApplication1.Data;
using WebApplication1.Data.Models;

namespace WebApplication1.Services
{
    public class AuthenticationService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;

        public AuthenticationService(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public string HashPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password);

        public bool VerifyPassword(string password, string hashed) => BCrypt.Net.BCrypt.Verify(password, hashed);

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
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}