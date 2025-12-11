using LoanTrack.Application.Dtos.Pago;
using LoanTrack.Application.Dtos.Prestamo;
using LoanTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTrack.Application.Interfaces.Services
{
    public interface IPagoService
    {
        Task<IEnumerable<PagoReadDto>> GetPagosEntreFechas(DateTime fechaInicio, DateTime fechaFin);
        Task<IEnumerable<PagoReadDto>> GetPagosPorPrestamo(int prestamoId);
        Task<decimal> GetTotalPagadoPorPrestamo(int prestamoId);
        Task<PagoReadDto> GetUltimoPago(int prestamoId);
        Task<PagoCreateDto> Create(PagoCreateDto pagoDto);
        Task<PagoUpdateDto> Update(PagoUpdateDto pagoDto);
        Task<bool> Delete(int pagoId);
        Task<ResultadoPagoDto> RegistrarPago(RegistrarPagoDto dto);
    }
}
