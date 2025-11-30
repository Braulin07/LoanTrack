using LoanTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTrack.Domain.Interfaces
{
    public interface IPrestamoRepository : IGenericRepository<Prestamo>
    {
        //obtener prestamos activos de un cliente
        Task<IEnumerable<Prestamo>> GetPrestamosActivosPorCliente(int idCliente);

        //obtener prestamos vencidos
        Task<IEnumerable<Prestamo>> GetPrestamosVencidos();

        //ver prestamos segun su estado
        Task<IEnumerable<Prestamo>> GetPrestamosPorEstado(string estado);

        //Calcular monto total de prestamos de un cliente
        Task<decimal> GetMontoTotalPrestamosPorCliente(int idCliente);

        //Lista de prestamos que deben ser pagados hoy
        Task<IEnumerable<Prestamo>> GetPrestamosConVencimientoHoy();
    }
}
