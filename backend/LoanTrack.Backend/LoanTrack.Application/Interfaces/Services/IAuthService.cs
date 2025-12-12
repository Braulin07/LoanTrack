using LoanTrack.Application.Dtos.Authentication;
using LoanTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTrack.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<AuthResponseDto> RegistrarAsync(RegisterUserRequestDto dto, CancellationToken cancellationToken);
        Task<AuthResponseDto> LoginAsync(LoginRequestDto dto, CancellationToken cancellationToken);
        string HashPassword(string password);
        bool VerifyPassword(string password, string hashedPassword);
        string GenerarJwtToken(Usuario usuario);
    }
}
