using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Data.Models;
using WebApplication1.DTOs;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly AuthenticationService _authService;

        public AuthenticationController(AppDbContext context, AuthenticationService authService)
        {
            _context = context;
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(AuthenticationRequest request)
        {
            if (await _context.Users.AnyAsync(u => u.Username == request.Username))
                return BadRequest("Username already exists.");

            var user = new User
            {
                Username = request.Username,
                Password = _authService.HashPassword(request.Password)
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok("User registered successfully.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(AuthenticationRequest request)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Username == request.Username);
            if (user == null || !_authService.VerifyPassword(request.Password, user.Password))
                return Unauthorized("Invalid username or password.");

            var token = _authService.GenerateJwtToken(user);
            return Ok(new { token });
        }

        [Authorize]
        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            // I don't include password in response but its there to showcase bcrypt hashing
            return Ok(users.Select(u => new { u.Id, u.Username, u.Password }));
        }
    }
}
