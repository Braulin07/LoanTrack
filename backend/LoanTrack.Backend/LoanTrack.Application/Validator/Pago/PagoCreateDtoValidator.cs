using FluentValidation;
using LoanTrack.Application.Dtos.Pago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTrack.Application.Validator.Pago
{
    public class PagoCreateDtoValidator: AbstractValidator<PagoCreateDto>
    {
        public PagoCreateDtoValidator()
        {
            RuleFor(x => x.MontoPagado)
                    .NotEmpty().WithMessage("El monto pagado deber ser obligatorio")
                    .GreaterThan(1).WithMessage("El pago debe ser mayor a RD$1.00");
            RuleFor(x => x.FechaPago)
                   .NotEmpty().WithMessage("Fecha de pago es obligatoria");
            RuleFor(x => x.MetodoPago)
                    .NotEmpty().WithMessage("Metodo de pago es obligatorio");
        }
    }
}
