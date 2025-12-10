using AutoMapper;
using FluentValidation;
using LoanTrack.Application.Dtos;
using LoanTrack.Application.Dtos.Cliente;
using LoanTrack.Application.Interfaces.Repositories;
using LoanTrack.Application.Interfaces.Services;
using LoanTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTrack.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repo;
        private readonly IMapper _mapper;
        private readonly IValidator<ClienteCreateDto> _validatorCR;
        private readonly IValidator<ClienteUpdateDto> _validatorUp;

        public ClienteService(IClienteRepository repo, IMapper Mapper,IValidator<ClienteCreateDto> validatorCr, IValidator<ClienteUpdateDto> validatorUp)
        {
            _repo = repo;
            _mapper = Mapper;
            _validatorCR = validatorCr;
            _validatorUp = validatorUp;
        }

        public async Task<ClienteReadDTO> Create(ClienteCreateDto dto)
        {
            await _validatorCR.ValidateAndThrowAsync(dto);

            var ValidacionCliente = await _repo.GetByCedula(dto.Cedula);
            if (ValidacionCliente != null)
            {
                throw new ArgumentException("Esta cedula ya esta registrada");
            }
            
            var entidad = _mapper.Map<Cliente>(dto);
             await _repo.Create(entidad);
            return _mapper.Map<ClienteReadDTO>(entidad);
        }

        public async Task<bool> Delete(int id)
        {

            var response = await _repo.GetById(id);
            if (response == null)
            {
                return false;
            }
            await _repo.Delete(response);
            return true;
        }

        public async Task<IEnumerable<ClienteReadDTO>> GetAll()
        {
            var users = await _repo.GetAll();
            return _mapper.Map<List<ClienteReadDTO>>(users);
        }

        public async Task<ClienteReadDTO> GetByCedula(string cedula)
        {
            var user = await _repo.GetByCedula(cedula);
            
            if (user == null)
                throw new KeyNotFoundException("Cliente no encontrado");

            return _mapper.Map<ClienteReadDTO>(user);
        }
    
        

        public async Task<ClienteReadDTO> GetById(int id)
        {
            var users = await _repo.GetById(id);

            if (users == null)
            {
                throw new KeyNotFoundException("Cliente no existe");
            }
            return _mapper.Map<ClienteReadDTO>(users);

        }

        public async Task<IEnumerable<ClienteReadDTO>> GetClientesActivos()
        {
            var users = await _repo.GetClientesActivos();

            return _mapper.Map<List<ClienteReadDTO>>(users);
        }
        public async Task<ClienteReadDTO> Update(int id, ClienteUpdateDto dto)
        {

            await _validatorUp.ValidateAndThrowAsync(dto);
            var cliente = await _repo.GetById(dto.ClienteId);
            if (cliente == null)
                throw new ArgumentException("Cliente no existe");

             _mapper.Map(dto, cliente);
               await _repo.Update(cliente);
            return _mapper.Map<ClienteReadDTO>(cliente);
        }

    }
}
