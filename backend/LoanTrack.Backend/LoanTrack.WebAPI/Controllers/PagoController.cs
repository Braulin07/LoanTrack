using LoanTrack.Application.Dtos.Pago;
using LoanTrack.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoanTrack.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : ControllerBase
    {
        private readonly IPagoService _service;
        public PagoController(IPagoService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("Crear")]
        public async Task<IActionResult> CreateAsync(PagoCreateDto pagoDto)
        {
            var result = await _service.Create(pagoDto);
            return Ok(result);
        }

        [HttpPut]
        [Route("Actualizar")]
        public async Task<IActionResult> UpdateAsync(PagoUpdateDto pagoDto)
        {
            var result = await _service.Update(pagoDto);
            return Ok(result);
        }

        [HttpDelete("{pagoId}")]
        public async Task<IActionResult> DeleteAsync(int pagoId)
        {
            var result = await _service.Delete(pagoId);
            return Ok(result);
        }

        [HttpGet]
        [Route("Pagos_Entre_Fechas")]
        public async Task<IActionResult> GetPagosEntreFechasAsync(DateOnly fechaInicio, DateOnly fechaFin)
        {
            var result = await _service.GetPagosEntreFechas(fechaInicio, fechaFin);
            return Ok(result);
        }

        [HttpGet]
        [Route("Pagos_Por_Prestamo")]
        public async Task<IActionResult> GetPagosPorPrestamoAsync(int prestamoId)
        {
            var result = await _service.GetPagosPorPrestamo(prestamoId);
            return Ok(result);
        }

        [HttpGet]
        [Route("Total_Pagado_Por_Prestamo")]
        public async Task<IActionResult> GetTotalPagadoPorPrestamoAsync(int prestamoId)
        {
            var result = await _service.GetTotalPagadoPorPrestamo(prestamoId);
            return Ok(result);
        }

        [HttpGet]
        [Route("Obterner_Ultimo_Pago")]
        public async Task<IActionResult> GetUltimoPagoAsync(int prestamoId)
        {
            var result = await _service.GetUltimoPago(prestamoId);
            return Ok(result);
        }
    }

}
