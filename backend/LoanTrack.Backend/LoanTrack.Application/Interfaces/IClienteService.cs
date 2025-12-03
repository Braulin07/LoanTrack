using LoanTrack.Application.Dtos;
using LoanTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTrack.Application.Interfaces
{
    public interface IClienteService
    {
        Task<ClienteReadDTO> GetByCedula(string cedula);

        Task<IEnumerable<ClienteReadDTO>> GetClientesActivos();

        Task<IEnumerable<ClienteReadDTO>> GetAll();

        Task<ClienteReadDTO> GetById(int id);

        Task<ClienteReadDTO> Create (ClienteCreateDto clienteCreateDto);
        Task<ClienteReadDTO> Update(int id, ClienteUpdateDto dto);
        Task<bool> Delete(int id);

    }
}
