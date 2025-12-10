using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTrack.Domain.Entities
{
    public class Cliente
    {
        public Cliente()
        {
            FechaRegistro = DateOnly.FromDateTime(DateTime.Now);
            Activo = true;
        }
        [Key]
        public int ClienteId { get; set; }
        [Required]
        [MaxLength(20)]
        public string Nombre { get; set; } = string.Empty;
        [MaxLength(20)]
        public string Apellido { get; set; } = string.Empty;
        [MaxLength(13)]
        public string Cedula { get; set; } = string.Empty;
        [MaxLength(12)]
        public string Telefono { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public DateOnly FechaRegistro { get; set; }
        public bool Activo { get; set; }

        //relaciones
        public ICollection<Prestamo> Prestamos { get; set; }
        public int? UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
