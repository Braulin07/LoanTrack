using LoanTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTrack.Application.Intereses
{
    public class InteresSimpleCalculator : ICalculadoraInteres
    {
        public decimal CaluladoraIntereses(Prestamo prestamo, DateTime fecha)
        {

            int meses = ((fecha.Year - prestamo.FechaInicio.Year) * 12)
                        + (fecha.Month - prestamo.FechaInicio.Month);

            if (meses < 1) meses = 1;

            return prestamo.MontoPrestado * prestamo.TasaInteres * meses;
        }


    }
}
