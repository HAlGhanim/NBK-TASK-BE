using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Interfaces;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthenticationController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(AuthenticationDTO request)
        {
            var result = await _authService.Register(request);
            return result == null
                ? Conflict("Username already exists.")
                : Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(AuthenticationDTO request)
        {
            var token = await _authService.Login(request);
            return token == null
                ? Unauthorized("Invalid username or password.")
                : Ok(new { token });
        }

        [Authorize]
        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _authService.GetAllUsers();
            return Ok(users.Select(u => new { u.Id, u.Username, u.Password }));
        }
    }
}
