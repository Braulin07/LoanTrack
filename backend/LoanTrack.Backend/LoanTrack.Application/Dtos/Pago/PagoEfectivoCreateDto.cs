using LoanTrack.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTrack.Application.Dtos.Pago
{
    public class PagoEfectivoCreateDto
    {
        public int PrestamoId { get; set; }
        public int ClienteId { get; set; }
        public decimal MontoPagado { get; set; }
        public EstadoPago EstadoPago { get; set; }
        public string? Observacion { get; set; }

    }
}
