using AutoMapper;
using LoanTrack.Application.Dtos;
using LoanTrack.Application.Interfaces;
using LoanTrack.Domain.Entities;
using LoanTrack.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTrack.Application.Services
{
    internal class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repo;
        private readonly IMapper _mapper;
        public ClienteService(IClienteRepository repo, IMapper Mapper)
        {
            _repo = repo;
            _mapper = Mapper;
        }

        public async Task Create(ClienteCreateDto clienteCreateDto)
        {
            var ValidacionCliente = await _repo.GetByCedula(clienteCreateDto.Cedula);
            if (ValidacionCliente != null)
            {

                throw new ArgumentException("Esta cedula ya esta registrada");
            }
            var entidad = _mapper.Map<Cliente>(clienteCreateDto);
            await _repo.Create(entidad);
        }

        public async Task Delete(int id)
        {
            var response = await _repo.GetById(id);
            if (response == null)
            {
                throw new ArgumentException("Cliente no existe");
            }
            await _repo.Delete(response);
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
            throw new ArgumentException("Cliente no existe");

            return _mapper.Map<ClienteReadDTO>(user);
        }
    
        

        public async Task<ClienteReadDTO> GetById(int id)
        {
            if (id != 0)
            {
                var users = await _repo.GetById(id);
                return _mapper.Map<ClienteReadDTO>(users);
            }
            throw new ArgumentException("Id no existe");

        }

        public async Task<IEnumerable<ClienteReadDTO>> GetClientesActivos()
        {
            var users = await _repo.GetClientesActivos();

            return _mapper.Map<List<ClienteReadDTO>>(users);
        }
        public async Task Update(ClienteUpdateDto clienteUpdateDto)
        {
            var cliente = await _repo.GetById(clienteUpdateDto.Id);
            
            if(clienteUpdateDto == null)
                throw new ArgumentException("Id no existe");

                _mapper.Map(clienteUpdateDto,cliente);
               await _repo.Update(cliente);
        }

    }
}
