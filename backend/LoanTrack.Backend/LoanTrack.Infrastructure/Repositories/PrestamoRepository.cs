using LoanTrack.Domain.Entities;
using LoanTrack.Domain.Enums;
using LoanTrack.Domain.Interfaces;
using LoanTrack.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTrack.Infrastructure.Repositories
{
    public class PrestamoRepository : GenericRepository<Prestamo>, IPrestamoRepository
    {
        public PrestamoRepository(AppDbContext context) : base(context)
        {
        }


        public async Task<decimal> GetPagoSaldoHoyPrestamosPorCliente(int clienteId)
        {
            return await _context.Prestamos
            .Where(x => x.ClienteId == clienteId)
            .SumAsync(x =>
            (x.MontoPrestado - x.MontoPagado) +
            ((x.MontoPrestado - x.MontoPagado) * x.TasaInteres * x.Plazo));

        }

        public async Task<IEnumerable<Prestamo>> GetPrestamosActivosPorCliente(int clienteId)
        {
            return await _context.Prestamos.Where(x => x.ClienteId == clienteId && x.Estado == EstadoPrestamo.Activo)
                                               .ToListAsync();
        }

        public async Task<IEnumerable<Prestamo>> GetPrestamosConVencimientoHoy()
        {
            DateOnly FechaHoy = DateOnly.FromDateTime(DateTime.Now);
            return await _context.Prestamos.Where(x => x.FechaVencimiento == FechaHoy).ToListAsync();
        }

        public async Task<IEnumerable<Prestamo>> GetPrestamosPorEstado(EstadoPrestamo estado)
        {
           return await _context.Prestamos.Where(x => x.Estado == estado).ToListAsync();
        }

        public async Task<IEnumerable<Prestamo>> GetPrestamosVencidos()
        {
            DateOnly FechaHoy = DateOnly.FromDateTime(DateTime.Now);
            return await _context.Prestamos.Where(x => x.FechaVencimiento <=FechaHoy).ToListAsync();
        }
    }
}
