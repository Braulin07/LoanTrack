using LoanTrack.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LoanTrack.Application.Interfaces;
using LoanTrack.Application.Dtos;
namespace LoanTrack.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _service;

        public ClienteController(IClienteService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteReadDTO>>> GetAll()
        {
            var user = await _service.GetAll();
            
            return Ok(user);
        }
        [HttpGet("id/{id:int}")]
        public async Task<ActionResult<ClienteReadDTO>> GetById(int id)
        {
            var user = await _service.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<ClienteReadDTO>> Create([FromBody] ClienteCreateDto dto)
        {
            var user = await _service.Create(dto);

            return CreatedAtAction(nameof(GetById), new { id = user.IdCliente }, user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ClienteReadDTO>> Update(int id, [FromBody] ClienteUpdateDto dto)
        {
            if (id != dto.Id)
                return BadRequest();
            var user = await _service.Update(id,dto);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.Delete(id);

            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpGet("activos")]
        public async Task<ActionResult<IEnumerable<ClienteReadDTO>>> ClientesActivos()
        {
            var user = await _service.GetClientesActivos();
            return Ok(user);
        }

        [HttpGet("cedula/{cedula}")]
        public async Task<ActionResult<ClienteReadDTO>> GetByCedula(string cedula)
        {
            var user = await _service.GetByCedula(cedula);
            return Ok(user);
        }
    }
}
