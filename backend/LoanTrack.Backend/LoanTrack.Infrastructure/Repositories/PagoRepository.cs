using LoanTrack.Domain.Entities;
using LoanTrack.Domain.Interfaces;
using LoanTrack.Infrastructure.Context;
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

        public Task<IEnumerable<Pago>> GetPagosEntreFechas(DateOnly fechaInicio, DateOnly fechaFin)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Pago>> GetPagosPorPrestamo(int idPrestamo)
        {
            throw new NotImplementedException();
        }

        public Task<decimal> GetTotalPagadoPorPrestamo(int idPrestamo)
        {
            throw new NotImplementedException();
        }

        public Task<Pago> GetUltimoPago(int idPrestamo)
        {
            throw new NotImplementedException();
        }
    }
}
