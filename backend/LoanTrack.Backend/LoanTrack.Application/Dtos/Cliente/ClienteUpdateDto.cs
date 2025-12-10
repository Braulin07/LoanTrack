using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTrack.Application.Dtos
{
    public class ClienteUpdateDto
    {
        public int ClienteId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        [MaxLength(20)]
        public string Apellido { get; set; } = string.Empty;
        [MaxLength(13)]
        public string Cedula { get; set; } = string.Empty;
        [MaxLength(12)]
        public string Telefono { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public bool Activo { get; set; }

    }
}
