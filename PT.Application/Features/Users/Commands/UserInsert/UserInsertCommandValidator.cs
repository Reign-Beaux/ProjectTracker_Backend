using FluentValidation;

namespace PT.Application.Features.Users.Commands.UserInsert
{
    public class UserInsertCommandValidator : AbstractValidator<UserInsertCommand>
    {
        public UserInsertCommandValidator()
        {
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("La contraseña es requerido.");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("El correo electrónico es requerido.");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El Nombre es requerido.");
            RuleFor(x => x.PaternalLastname)
                .NotEmpty().WithMessage("El Apellido paterno es requerido.");
        }
    }
}
