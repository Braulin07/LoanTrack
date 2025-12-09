using LoanTrack.Application.Dtos.Usuario;
using LoanTrack.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoanTrack.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;

        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("Buscar Usuarios y sus Clientes")]
        public async Task<IActionResult?> GetConClienteAsync(int usuarioId)
        {
            return Ok(await _service.GetConClienteAsync(usuarioId));
        }
    }
}
