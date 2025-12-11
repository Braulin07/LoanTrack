using LoanTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTrack.Application.Interfaces.Repositories
{
    public interface IPagoRepository : IGenericRepository<Pago>
    {
        //Este es para obtener todos los pagos de un prestamo específico
        Task<IEnumerable<Pago>> GetPagosPorPrestamo(int idPrestamo);

        //Aqui obtengo los pagos en un rango de fecha
        Task<IEnumerable<Pago>> GetPagosEntreFechas(DateTime fechaInicio, DateTime fechaFin);

        //para ver el total pagado por un prestamo
        Task<decimal> GetTotalPagadoPorPrestamo(int idPrestamo);

        //para obtener el último pago realizado de un prestamo
        Task<Pago> GetUltimoPago(int idPrestamo);
    }
}
