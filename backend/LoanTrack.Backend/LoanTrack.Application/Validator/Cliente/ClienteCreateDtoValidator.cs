using FluentValidation;
using LoanTrack.Application.Dtos.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTrack.Application.Validator.Cliente
{
    public class ClienteCreateDtoValidator : AbstractValidator<ClienteCreateDto>
    {
        public ClienteCreateDtoValidator()
        {
            RuleFor(x => x.Nombre)
                    .NotEmpty().WithMessage("El nombre es obligatorio")
                    .MaximumLength(50).WithMessage("El nombre no puede tener mas de 50 caracteres");
            RuleFor(x => x.Apellido)
                    .NotEmpty().WithMessage("El apellido es obligatorio")
                    .MaximumLength(80).WithMessage("El apellido no puede tener mas de 80 caracteres");

            RuleFor(x => x.Cedula)
                   .NotEmpty().WithMessage("Cedula es Obligatorio")
                   .Length(11).WithMessage("Cedula debe tener 11 digitos");
            RuleFor(x => x.Telefono)
                    .NotEmpty().WithMessage("El telefono es obligatorio")
                    .Length(10).WithMessage("Telefono debe tener 10 digitos");
            RuleFor(x => x.Correo)
                    .NotEmpty().WithMessage("El correo es obligatorio")
                    .EmailAddress().WithMessage("El formato de correo no es valido");
            RuleFor(x => x.Activo)
                .NotEmpty().WithMessage("No puede ser nulo");
        }
    }
}
