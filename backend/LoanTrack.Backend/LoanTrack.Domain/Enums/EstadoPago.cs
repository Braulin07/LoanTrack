using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTrack.Domain.Enums
{
    public enum EstadoPago
    {
        PENDIENTE = 1,
        EN_TRANSITO = 2,
        COMPLETADO = 3,
        CANCELADO = 4
    }
}
