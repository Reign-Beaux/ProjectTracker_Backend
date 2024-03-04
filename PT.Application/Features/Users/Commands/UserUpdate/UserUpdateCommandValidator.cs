using FluentValidation;

namespace PT.Application.Features.Users.Commands.UserUpdate
{
    public class UserUpdateCommandValidator : AbstractValidator<UserUpdateCommand>
    {
        public UserUpdateCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("El correo electrónico es requerido.");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El Nombre es requerido.");
            RuleFor(x => x.PaternalLastname)
                .NotEmpty().WithMessage("El Apellido paterno es requerido.");
        }
    }
}
