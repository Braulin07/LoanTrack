using LoanTrack.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTrack.Domain.Entities
{
    public class Oferta
    {
        [Key]
        public int OfertaId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Titulo { get; set; } = string.Empty;

        [MaxLength(250)]
        public string Descripcion { get; set; } = string.Empty;

        [Required]
        public TipoOferta TipoOferta { get; set; }

        [Range(0, 100)]
        public decimal PorcentajeDescuento { get; set; }

        [MaxLength(250)]
        public string Condicion { get; set; } = string.Empty;

        [Required]
        public DateTime FechaInicio { get; set; }

        [Required]
        public DateTime FechaFin { get; set; }

        public bool Activo { get; set; } = true;

        // Auditoría básica
        [Required]
        public int CreadoPorUsuarioId { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    }
}
