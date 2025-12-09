using AutoMapper;
using FluentValidation;
using LoanTrack.Application.Dtos.Pago;
using LoanTrack.Application.Dtos.Usuario;
using LoanTrack.Application.Interfaces.Repositories;
using LoanTrack.Application.Interfaces.Services;
using LoanTrack.Domain.Entities;
using LoanTrack.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTrack.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repo;
        private readonly IMapper _mapper;
        private readonly IValidator<PagoCreateDto> _validatorCr;
        private readonly IValidator<PagoUpdateDto> _validatorUp;

        public UsuarioService(IUsuarioRepository repo, IMapper mapper, IValidator<PagoCreateDto> validatorCr, IValidator<PagoUpdateDto> validatorUp)
        {
            _repo = repo;
            _mapper = mapper;
            _validatorCr = validatorCr;
            _validatorUp = validatorUp;
        }


        public async Task ActualizarUltimoLoginAsync(int usuarioId)
        {

            await _repo.ActualizarUltimoLoginAsync(usuarioId);
        }

        public async Task<bool> EmailExisteAsync(string email)
        {
            return await _repo.EmailExisteAsync(email); ;
        }

        public async Task<IEnumerable<UsuarioReadDto>> GetByRolAsync(RolUsuario rol)
        {
            var entidad = await _repo.GetByRolAsync(rol);
            var dto = _mapper.Map<IEnumerable<UsuarioReadDto>>(entidad);

            return dto;
        }

        public async Task<UsuarioReadDto?> GetConClienteAsync(int usuarioId)
        {
            var entidad = await _repo.GetConClienteAsync(usuarioId);
            var dto = _mapper.Map<UsuarioReadDto>(entidad);

            return dto;
        }

        public async Task<UsuarioReadDto?> GetPorEmailAsync(string email)
        {
            var entidad = await _repo.GetPorEmailAsync(email);
            var dto = _mapper.Map<UsuarioReadDto>(entidad);

            return dto;
        }
    }
}
