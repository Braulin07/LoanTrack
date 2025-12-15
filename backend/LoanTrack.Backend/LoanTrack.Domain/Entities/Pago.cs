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

        // Montos
        [Required]
        public decimal MontoPagado { get; set; }

        public decimal MontoInteres { get; set; }

        public decimal MontoCapital { get; set; }

        public decimal MontoDescuento { get; set; }

        public decimal MontoFinalPagado { get; set; }

        // Fechas
        public DateTime FechaPago { get; set; }

        public DateTime? FechaGeneracionCodigo { get; set; }

        public DateTime? FechaExpiracionCodigo { get; set; }

        // Pago
        [Required]
        public MetodoPago MetodoPago { get; set; }

        [Required]
        public EstadoPago EstadoPago { get; set; }

        [MaxLength(20)]
        public string? CodigoPagoEfectivo { get; set; }

        [MaxLength(100)]
        public string? ReferenciaExterna { get; set; }

        [MaxLength(250)]
        public string Observacion { get; set; } = string.Empty;

        // Relaciones
        [Required]
        public int PrestamoId { get; set; }
        public Prestamo Prestamo { get; set; }

        [Required]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public int? OfertaId { get; set; }
        public Oferta? Oferta { get; set; }

        // Seguridad / trazabilidad
        [Required]
        public int RegistradoPorUsuarioId { get; set; }
        public Usuario RegistradoPorUsuario { get; set; }
    }
}
