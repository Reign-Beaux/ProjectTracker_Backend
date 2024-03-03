using FluentValidation;

namespace PT.Application.Features.Auth.Commands.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(x => x.UsernameOrEmail)
                .NotEmpty().WithMessage("El Usuario o Contraseña es requerido.");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("La contraseña es requerida");
        }
    }
}
