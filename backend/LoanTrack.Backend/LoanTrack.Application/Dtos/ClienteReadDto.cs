using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTrack.Application.Dtos
{
    public class ClienteReadDTO
    {
        public int IdCliente { get; set; }

        public string Nombre { get; set; } = string.Empty;
        
        public string Apellido { get; set; } = string.Empty;
        
        public string Cedula { get; set; } = string.Empty;
        
        public string Telefono { get; set; } = string.Empty;
        
        public string Correo { get; set; } = string.Empty;
        
        public string Direccion { get; set; } = string.Empty;
        
        public DateOnly FechaRegistro { get; set; }
        
        public bool Activo { get; set; }

    }
}
