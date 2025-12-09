using LoanTrack.Application.Dtos.Prestamo;
using LoanTrack.Application.Interfaces.Services;
using LoanTrack.Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoanTrack.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamoController : ControllerBase
    {
        private readonly IPrestamoService _service;

        public PrestamoController(IPrestamoService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("Crear")]
        public async Task<IActionResult> CreateAsync(PrestamoCreateDto createDto)
        {
            var result = await _service.Create(createDto);
            return Ok(result);
        }

        [HttpPut]
        [Route("Actualizar")]
        public async Task<IActionResult> UpdateAsync(PrestamoUpdateDto updatedto)
        {
            var result = await _service.Update(updatedto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _service.Delete(id);
            return Ok(result);
        }


        [HttpGet("{idCliente}")]
        public async Task<IActionResult> GetPrestamosActivosPorClienteAsync(int idCliente)
        {
            var response = await _service.GetPrestamosActivosPorCliente(idCliente);
            return Ok(response);
        }


        [HttpGet]
        [Route("Prestamos_Con_Vencimiento_Hoy")]
        public async Task<IActionResult> GetPrestamosConVencimientoHoyAsync()
        {
            var response = await _service.GetPrestamosConVencimientoHoy();
            return Ok(response);
        }

        [HttpGet]
        [Route("Prestamos_Por_Estado")]
        public async Task<IActionResult> GetPrestamosPorEstadoAsync(EstadoPrestamo estado)
        {
            var response = await _service.GetPrestamosPorEstado(estado);
            return Ok(response);
        }

        [HttpGet]
        [Route("Prestamos_Vencidos")]
        public async Task<IActionResult> GetPrestamosVencidosAsync()
        {
            var response = await _service.GetPrestamosVencidos();
            return Ok(response);
        }

    }
}
