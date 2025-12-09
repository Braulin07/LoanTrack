using LoanTrack.Application.Interfaces.Repositories;
using LoanTrack.Domain.Entities;
using LoanTrack.Domain.Enums;
using LoanTrack.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTrack.Infrastructure.Repositories
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(AppDbContext context) : base(context)
        {
        }

        public async Task ActualizarUltimoLoginAsync(int usuarioId)
        {
            await _context.Usuarios
                .Where(x => x.UsuarioId == usuarioId)
                .ExecuteUpdateAsync(x => x.SetProperty(u => u.UltimoLogin, DateTime.UtcNow));
        }

        public async Task<bool> EmailExisteAsync(string email)
        {
            return await _context.Usuarios
                .Where(x => x.Email == email)
                .AnyAsync();
        }

        public async Task<IEnumerable<Usuario>> GetByRolAsync(RolUsuario rol)
        {
            return await _context.Usuarios
                .Where(x => x.Rol == rol)
                .ToListAsync();
        }

        public async Task<Usuario?> GetConClienteAsync(int usuarioId)
        {
            return await _context.Usuarios
                .Where(x => x.UsuarioId == usuarioId)
                .Include(x => x.Cliente)
                .FirstOrDefaultAsync();
        }

        public async Task<Usuario?> GetPorEmailAsync(string email)
        {
            return await _context.Usuarios
                .Where(x => x.Email == email)
                .FirstOrDefaultAsync();
        }
    }
}
