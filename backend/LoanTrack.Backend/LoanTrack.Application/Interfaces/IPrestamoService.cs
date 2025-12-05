using LoanTrack.Application.Dtos.Cliente;
using LoanTrack.Application.Dtos;
using LoanTrack.Application.Dtos.Prestamo;
using LoanTrack.Domain.Entities;
using LoanTrack.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTrack.Application.Interfaces
{
    public interface IPrestamoService
    {
        Task<IEnumerable<PrestamoReadDto>> GetPrestamosActivosPorCliente(int idCliente);
        Task<IEnumerable<PrestamoReadDto>> GetPrestamosConVencimientoHoy();
        Task<IEnumerable<PrestamoReadDto>> GetPrestamosPorEstado(EstadoPrestamo estado);
        Task<IEnumerable<PrestamoReadDto>> GetPrestamosVencidos();
        Task<PrestamoCreateDto> Create(PrestamoCreateDto createDto);
        Task<PrestamoUpdateDto> Update(PrestamoUpdateDto dto);
        Task<bool> Delete(int id);
    }
}
