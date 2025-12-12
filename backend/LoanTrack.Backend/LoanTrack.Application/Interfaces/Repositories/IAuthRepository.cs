using LoanTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTrack.Application.Interfaces.Repositories
{
    public interface IAuthRepository
    {
        Task<Usuario> GetPorEmailAsync(string email, CancellationToken cancellationToken = default);
        Task AgregarAsync(Usuario usuario, CancellationToken cancellationToken = default);
        Task<bool> EmailExistenteAsync(string email, CancellationToken cancellationToken = default);
        Task<Usuario> BuscarPorIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
