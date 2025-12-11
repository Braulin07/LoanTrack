using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTrack.Application.Dtos.Pago
{
    public class RegistrarPagoDto
    {
        public int prestamoId { get; set; }
        public decimal montoPago { get; set; }
    }
}
