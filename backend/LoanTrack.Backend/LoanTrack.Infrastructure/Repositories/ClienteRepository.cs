using LoanTrack.Domain.Entities;
using LoanTrack.Domain.Interfaces;
using LoanTrack.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTrack.Infrastructure.Repositories
{
    public class ClienteRepository : GenericRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Cliente> GetByCedula(string cedula)
        {
            return await _context.Clientes.FirstOrDefaultAsync(c => c.Cedula == cedula);
        }

        public async Task<IEnumerable<Cliente>> GetClientesActivos()
        {
            return await _context.Clientes.Where(c => c.Activo).ToListAsync();
        }
    }
}
