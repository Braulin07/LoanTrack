using LoanTrack.Domain.Entities;
using LoanTrack.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTrack.Application.Interfaces.Repositories
{
    public interface IUsuarioRepository : IGenericRepository<Usuario>
    {
        Task<Usuario?> GetPorEmailAsync(string email);
        Task<bool> EmailExisteAsync(string email);
        Task<IEnumerable<Usuario>> GetByRolAsync(RolUsuario rol);
        Task<Usuario?> GetConClienteAsync(int usuarioId);
        Task ActualizarUltimoLoginAsync(int usuarioId);
    }
}
