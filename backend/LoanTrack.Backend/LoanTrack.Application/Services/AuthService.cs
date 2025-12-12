using AutoMapper;
using BCrypt.Net;
using LoanTrack.Application.Dtos.Authentication;
using LoanTrack.Application.Interfaces.Repositories;
using LoanTrack.Application.Interfaces.Services;
using LoanTrack.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace LoanTrack.Application.Services
{
    internal class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepo;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AuthService(
            IAuthRepository authRepo,
            IMapper mapper,
            IConfiguration configuration
            )
        {
            _authRepo = authRepo;
            _mapper = mapper;
            _configuration = configuration;
        }


        //Metodo para generar JWT aqui instale el paquete de: using Microsoft.IdentityModel.Tokens; y using System.IdentityModel.Tokens.Jwt;
        public string GenerarJwtToken(Usuario usuario)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]);


            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, usuario.UsuarioId.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                new Claim("role", usuario.Rol.ToString()),
                new Claim("status", usuario.Activo.ToString())
            };

            var creds = new SigningCredentials
            (
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256
            );

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(3),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        //Metodo par aconvertir contraseña a contraseña hasheada para esto isntalamos el paquete: using BCrypt.Net;
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }


        //Metodo para verificar que las contraseñas macheen, una no haseada(DTO) y otra si hasheada(Entidad BD)
        public bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }


        public async Task<AuthResponseDto> LoginAsync(LoginRequestDto dto, CancellationToken cancellationToken)
        {
            var entidad = await _authRepo.GetPorEmailAsync(dto.Email, cancellationToken);
            if (entidad == null) throw new UnauthorizedAccessException("Credenciales Invalida");

            var contraseñaExiste = VerifyPassword(dto.Password, entidad.PasswordHash);
            if (!contraseñaExiste) throw new UnauthorizedAccessException("Credenciales Invalida");

            var token = GenerarJwtToken(entidad);

            var responseDto = _mapper.Map<AuthResponseDto>(entidad);
            responseDto.Token = token;

            return responseDto;
        }

        public async Task<AuthResponseDto> RegistrarAsync(RegisterUserRequestDto dto, CancellationToken cancellationToken)
        {
            var emailExiste = await _authRepo.EmailExistenteAsync(dto.Email, cancellationToken);
            if (emailExiste) throw new Exception("Correo Utilizado ya existe");

            var entidad = _mapper.Map<Usuario>(dto);

            entidad.PasswordHash = HashPassword(dto.Password);

            await _authRepo.AgregarAsync(entidad, cancellationToken);

            var token = GenerarJwtToken(entidad);

            var responseDto = _mapper.Map<AuthResponseDto>(entidad);
            responseDto.Token = token;

            return responseDto;
        }

        
    }
}
