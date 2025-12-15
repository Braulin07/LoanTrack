using LoanTrack.Application.Dtos.Authentication;
using LoanTrack.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoanTrack.WebAPI.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Registrarse")]
        public async Task<IActionResult> Registrarse([FromBody] RegisterUserRequestDto dto, CancellationToken cancellationToken)
        {
            return Ok(await _authService.RegistrarAsync(dto, cancellationToken));
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto dto, CancellationToken cancellationToken)
        {
            return Ok(await _authService.LoginAsync(dto, cancellationToken));
        }
    }
}
