using AutoMapper;
using LoanTrack.Application.Dtos;
using LoanTrack.Application.Dtos.Cliente;
using LoanTrack.Application.Interfaces.Repositories;
using LoanTrack.Application.Interfaces.Services;
using LoanTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTrack.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repo;
        private readonly IMapper _mapper;
        public ClienteService(IClienteRepository repo, IMapper Mapper)
        {
            _repo = repo;
            _mapper = Mapper;
        }

        public async Task<ClienteReadDTO> Create(ClienteCreateDto dto)
        {
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

            var cliente = await _repo.GetById(dto.ClienteId);

            if (cliente == null)
                throw new ArgumentException("Cliente no existe");

             _mapper.Map(dto, cliente);
               await _repo.Update(cliente);
            return _mapper.Map<ClienteReadDTO>(cliente);
        }

    }
}
