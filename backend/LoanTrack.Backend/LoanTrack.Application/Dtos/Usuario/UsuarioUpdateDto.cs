using LoanTrack.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTrack.Application.Dtos.Usuario
{
    public class UsuarioUpdateDto
    {
        public int UsuarioId { get; set; }
        public RolUsuario Rol { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string? Telefono { get; set; }
    }
}
