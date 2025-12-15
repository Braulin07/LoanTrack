using LoanTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTrack.Application.Intereses
{
    public class InteresDiarioCalculator: ICalculadoraInteres
    {
        public decimal CaluladoraIntereses(Prestamo prestamo, DateTime fecha)
        {
            int dias = (fecha - prestamo.FechaInicio).Days;
            if (dias < 1) dias = 1;

            decimal tasaDiaria = prestamo.TasaInteres / 30;

            decimal saldo = prestamo.MontoPrestado - prestamo.MontoPagado;
            if (saldo < 0) saldo = 0;

            return saldo * tasaDiaria * dias;
        }
    }
}
