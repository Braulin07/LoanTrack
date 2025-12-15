using FluentValidation;
using LoanTrack.Application.Dtos.Pago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTrack.Application.Validator.Pago
{
    public class RegistrarPagoValidator: AbstractValidator<RegistrarPagoDto>
    {
        public RegistrarPagoValidator()
        {
            RuleFor(x => x.prestamoId)
                .NotEmpty().WithMessage("Prestamo no encontrado");
        }
    }
}
