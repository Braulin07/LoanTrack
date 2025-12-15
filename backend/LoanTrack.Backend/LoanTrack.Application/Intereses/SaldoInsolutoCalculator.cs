using LoanTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTrack.Application.Intereses
{
    public class SaldoInsolutoCalculator : ICalculadoraInteres
    {
        public decimal CaluladoraIntereses(Prestamo prestamo, DateTime fecha)
        {
            decimal saldo = prestamo.MontoPrestado - prestamo.MontoPagado;
            if (saldo < 0) saldo = 0;

            int meses = (fecha - prestamo.FechaInicio).Days / 30;
            if (meses < 1) meses = 1;

            return saldo * prestamo.TasaInteres * meses;
        }
    }
}
