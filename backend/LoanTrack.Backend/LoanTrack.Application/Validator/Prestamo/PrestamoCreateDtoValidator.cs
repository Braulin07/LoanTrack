using FluentValidation;
using LoanTrack.Application.Dtos.Prestamo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
namespace LoanTrack.Application.Validator.Prestamo
{
    internal class PrestamoCreateDtoValidator:AbstractValidator<PrestamoCreateDto>
    {
        public PrestamoCreateDtoValidator()
        {
            RuleFor(x => x.MontoPrestado)
                    .GreaterThanOrEqualTo(1).WithMessage("El monto a prestado debe ser mayor a 1")
                    .NotEmpty().WithMessage("El Monto a prestado es obligatorio");
            RuleFor(x => x.TasaInteres)
                    .NotEmpty().WithMessage("La tasa de interes es obligatoria");
            RuleFor(x => x.Plazo)
                    .NotEmpty().WithMessage("El Plazo es obligatorio");
            RuleFor(x => x.MontoTotal)
                    .NotEmpty().WithMessage("El MontoTotal es obligatorio");
            RuleFor(x => x.FechaInicio)
                   .NotEmpty().WithMessage("La FechaInicio es obligatorio");
            RuleFor(x => x.FechaVencimiento)
                   .NotEmpty().WithMessage("La FechaVencimiento es obligatorio");
            RuleFor(x => x.Estado)
                   .NotEmpty().WithMessage("El Estado es obligatorio");
        }
    }
}
