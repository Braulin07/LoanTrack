using FluentValidation;
using LoanTrack.Application.Dtos.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTrack.Application.Validator.Usuario
{
    public class UsuarioCreateDtoValidator : AbstractValidator<UsuarioCreateDto>
    {
        public UsuarioCreateDtoValidator()
        {
            
            RuleFor(x => x.Rol)
                .IsInEnum().WithMessage("Debe indicar un rol válido.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("El email es obligatorio.")
                .EmailAddress().WithMessage("Debe proporcionar un email válido.")
                .MaximumLength(150).WithMessage("El email no debe exceder 150 caracteres.");

            RuleFor(x => x.PasswordHash)
                .NotEmpty().WithMessage("La contraseña es obligatoria.")
                .MinimumLength(6).WithMessage("La contraseña debe tener al menos 6 caracteres.")
                .MaximumLength(200).WithMessage("La contraseña no debe exceder 200 caracteres.");

            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre no debe exceder 50 caracteres.");

            RuleFor(x => x.Apellido)
                .NotEmpty().WithMessage("El apellido es obligatorio.")
                .MaximumLength(50).WithMessage("El apellido no debe exceder 50 caracteres.");

            RuleFor(x => x.Telefono)
                .MaximumLength(12).WithMessage("El teléfono no debe exceder 12 caracteres.")
                .Matches(@"^[0-9]*$").WithMessage("El teléfono solo puede contener números.")
                .When(x => !string.IsNullOrWhiteSpace(x.Telefono));
        }
    }
}
