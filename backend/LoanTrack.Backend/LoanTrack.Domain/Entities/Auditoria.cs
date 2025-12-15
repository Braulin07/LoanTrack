using LoanTrack.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTrack.Domain.Entities
{
    public class Auditoria
    {
        [Key]
        public int AuditoriaId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Entidad { get; set; } = string.Empty;

        [Required]
        public int EntidadId { get; set; }

        [Required]
        public AccionAuditoria Accion { get; set; }

        [Required]
        [MaxLength(250)]
        public string DescripcionCambio { get; set; } = string.Empty;

        [Required]
        public DateTime FechaCambio { get; set; } = DateTime.UtcNow;

        // Usuario que realizó la acción
        [Required]
        public int UsuarioId { get; set; }

        [Required]
        [EmailAddress]
        public string EmailUsuario { get; set; } = string.Empty;

        [Required]
        public RolUsuario RolUsuario { get; set; }

        public bool EsOperacionCritica { get; set; }

        [MaxLength(45)]
        public string? IpOrigen { get; set; }
    }
}
