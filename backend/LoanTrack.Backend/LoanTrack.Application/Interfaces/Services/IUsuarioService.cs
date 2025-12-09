using LoanTrack.Application.Dtos.Usuario;
using LoanTrack.Domain.Entities;
using LoanTrack.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTrack.Application.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<UsuarioReadDto?> GetPorEmailAsync(string email);
        Task<bool> EmailExisteAsync(string email);
        Task<IEnumerable<UsuarioReadDto>> GetByRolAsync(RolUsuario rol);
        Task<UsuarioReadDto?> GetConClienteAsync(int usuarioId);
        Task ActualizarUltimoLoginAsync(int usuarioId);
    }
}
