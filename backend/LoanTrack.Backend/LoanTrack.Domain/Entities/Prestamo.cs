using LoanTrack.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTrack.Domain.Entities
{
    public class Prestamo
    {
     

        [Key]
        public int PrestamoId { get; set; }
        public decimal MontoPrestado { get; set; }
        [Range(1,100)]
        public decimal TasaInteres { get; set; }
        public int Plazo {  get; set; } // en meses
        public  decimal MontoTotal { get; set; }
        public decimal InteresesPagados { get; set; }
        public decimal MontoPagado { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public DateTime FechaUltimoPago { get; set; }

        public EstadoPrestamo Estado { get; set; }

        //relaciones
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public ICollection<Pago> Pagos { get; set; }
    }
}
