using LoanTrack.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTrack.Application.Dtos.Pago
{
    public class PagoCreateDto
    {
        public decimal MontoPagado { get; set; }
        public DateTime FechaPago { get; set; }
        public MetodoPago MetodoPago { get; set; }
        public string Observacion { get; set; } = string.Empty;
        public int PrestamoId { get; set; }
    }
}
