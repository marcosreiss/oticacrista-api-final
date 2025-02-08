using Microsoft.AspNetCore.Mvc;
using OticaCrista.Data.Repository;
using OticaCrista.Models;
using OticaCrista.Services;

namespace OticaCrista.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthRepository _authRepository;
        private readonly AuthService _authService;

        public AuthController(AuthRepository authRepository, AuthService authService)
        {
            _authRepository = authRepository;
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var user = new ApplicationUser { UserName = model.Username, Email = model.Email };
            var result = await _authRepository.RegisterUserAsync(user, model.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok(new { message = "User registered successfully" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _authRepository.FindUserByNameAsync(model.Username);
            if (user == null || !await _authRepository.CheckPasswordAsync(user, model.Password))
                return Unauthorized(new { message = "Invalid credentials" });

            var token = await _authService.GenerateJwtToken(user);
            return Ok(new { token });
        }

        [HttpPost("assign-role")]
        public async Task<IActionResult> AssignRole([FromBody] AssignRoleModel model)
        {
            var success = await _authRepository.AssignRoleAsync(model.Username, model.Role);
            if (!success)
                return BadRequest(new { message = "Failed to assign role" });

            return Ok(new { message = "Role assigned successfully" });
        }
    }
}
