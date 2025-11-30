using LoanTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTrack.Domain.Interfaces
{
    public interface IClienteRepository : IGenericRepository<Cliente>
    {
        //Aqui puedo obtener Cliente especifico por cedula
        Task<Cliente> GetByCedula(string cedula);
        //Aqui obtengo una lista de los clientes activos
        Task<IEnumerable<Cliente>> GetClientesActivos();
    }
}
