using FluentValidation;

namespace PT.Application.Features.Roles.Commands.RoleUpdate
{
    public class RoleUpdateCommandValidator : AbstractValidator<RoleUpdateCommand>
    {
        public RoleUpdateCommandValidator()
        {
            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("El código es requerido.");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("La descripción es requerida");
        }
    }
}
