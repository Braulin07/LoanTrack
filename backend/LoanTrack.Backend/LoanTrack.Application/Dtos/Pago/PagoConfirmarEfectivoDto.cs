using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTrack.Application.Dtos.Pago
{
    public class PagoConfirmarEfectivoDto
    {
        public int PagoId { get; set; }
        public string CodigoPagoEfectivo { get; set; }
    }
}
