using LoanTrack.Domain.Entities;
using LoanTrack.Domain.Enums.LoanTrack.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTrack.Application.Intereses
{
    internal class CalculadoraInteresFactory
    { 
        public static ICalculadoraInteres GetCalculator(TipoInteres tipo)
        {
            return tipo switch
            {
                TipoInteres.Simple => new InteresSimpleCalculator(),
                TipoInteres.SaldoInsoluto => new SaldoInsolutoCalculator(),
                TipoInteres.Diario => new InteresDiarioCalculator(),
                TipoInteres.Flat => new InteresFlatCalculator(),
            };

        }
            
    }
}
