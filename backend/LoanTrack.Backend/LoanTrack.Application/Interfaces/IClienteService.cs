using LoanTrack.Application.Dtos;
using LoanTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTrack.Application.Interfaces
{
    internal interface IClienteService
    {
        Task<ClienteReadDTO> GetByCedula(string cedula);

        Task<IEnumerable<ClienteReadDTO>> GetClientesActivos();

        Task<IEnumerable<ClienteReadDTO>> GetAll();

        Task<ClienteReadDTO> GetById(int id);

        Task Create (ClienteCreateDto clienteCreateDto);

        Task Update(ClienteUpdateDto clienteUpdateDto);
        Task Delete(int id);

    }
}
