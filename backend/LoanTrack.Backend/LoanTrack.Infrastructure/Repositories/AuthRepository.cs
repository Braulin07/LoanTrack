using LoanTrack.Application.Interfaces.Repositories;
using LoanTrack.Domain.Entities;
using LoanTrack.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTrack.Infrastructure.Repositories
{
    public class AuthRepository: GenericRepository<Usuario>, IAuthRepository
    {
        public AuthRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AgregarAsync(Usuario usuario, CancellationToken cancellationToken = default)
        {
            await _context.Usuarios.AddAsync(usuario, cancellationToken);
            await _context.SaveChangesAsync();
        }

        public async Task<Usuario?> BuscarPorIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.UsuarioId == id, cancellationToken);
        }

        public async Task<bool> EmailExistenteAsync(string email, CancellationToken cancellationToken = default)
        {
            return await _context.Usuarios
                .AsNoTracking()
                .AnyAsync(x => x.Email.ToLower() == email.ToLower(), cancellationToken);

        }

        public async Task<Usuario?> GetPorEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            return await _context.Usuarios
               .AsNoTracking()
               .FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower(), cancellationToken);
        }
    }
}
