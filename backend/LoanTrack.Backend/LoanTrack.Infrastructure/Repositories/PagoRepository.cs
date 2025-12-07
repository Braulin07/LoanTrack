using LoanTrack.Domain.Entities;
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
    public class PagoRepository : GenericRepository<Pago>, IPagoRepository
    {
        public PagoRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Pago>> GetPagosEntreFechas(DateOnly fechaInicio, DateOnly fechaFin)
        {
            return await _context.Pagos
                .Where(x => x.FechaPago >= fechaInicio && x.FechaPago <= fechaFin)
                .ToListAsync();
        }

        public async Task<IEnumerable<Pago>> GetPagosPorPrestamo(int prestamoId)
        {
            return await _context.Pagos
                .Where(x => x.PrestamoId == prestamoId)
                .ToListAsync();
        }

        public async Task<decimal> GetTotalPagadoPorPrestamo(int prestamoId)
        {
            return await _context.Pagos
                .Where(x => x.PrestamoId == prestamoId)
                .SumAsync(x => x.MontoPagado);
        }

        public async Task<Pago> GetUltimoPago(int prestamoId)
        {
            return await _context.Pagos
                .Where(x => x.PrestamoId == prestamoId)
                .OrderByDescending(x => x.FechaPago)
                .LastAsync();
        }
    }
}
