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
    public class PrestamoRepository : GenericRepository<Prestamo>, IPrestamoRepository
    {
        public PrestamoRepository(AppDbContext context) : base(context)
        {
        }

        public Task<decimal> GetMontoTotalPrestamosPorCliente(int idCliente)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Prestamo>> GetPrestamosActivosPorCliente(int idCliente)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Prestamo>> GetPrestamosConVencimientoHoy()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Prestamo>> GetPrestamosPorEstado(string estado)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Prestamo>> GetPrestamosVencidos()
        {
            throw new NotImplementedException();
        }
    }
}
