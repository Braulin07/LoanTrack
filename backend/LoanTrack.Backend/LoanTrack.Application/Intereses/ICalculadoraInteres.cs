using LoanTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTrack.Application.Intereses
{
    public interface ICalculadoraInteres
    {
        decimal CaluladoraIntereses(Prestamo prestamo, DateTime fecha);
    }
}
