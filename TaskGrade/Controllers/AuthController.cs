using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskGrade.Infrastructure.Abstraction;
using TaskGrade.Models;

namespace TaskGrade.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromQuery] LoginRequest request)
        {
            var token = await _authService.LoginAsync(request.Name, request.Email);

            return Ok(token);
        }
    }
}
