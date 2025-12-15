using LoanTrack.Domain.Enums;
using LoanTrack.Domain.Enums.LoanTrack.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTrack.Application.Dtos.Prestamo
{
    public class PrestamoCreateDto
    {
        public decimal MontoPrestado { get; set; }
        public decimal TasaInteres { get; set; }
        public int Plazo { get; set; }
        public DateTime FechaInicio { get; set; }
        public EstadoPrestamo Estado { get; set; }
        public TipoInteres Tinteres { get; set; }
        public int ClienteId { get; set; }
    }
}
