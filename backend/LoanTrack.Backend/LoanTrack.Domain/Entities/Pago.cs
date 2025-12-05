using LoanTrack.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTrack.Domain.Entities
{
    public class Pago
    {
        [Key]
        public int PagoId { get; set; }
        public decimal MontoPagado { get; set; }
        public DateOnly FechaPago { get; set; }
        public MetodoPago MetodoPago { get; set; }
        public string Observacion { get; set; } = string.Empty;

        //relaciones
        public int PrestamoId { get; set; }
        public Prestamo Prestamo { get; set; }
    }
}
