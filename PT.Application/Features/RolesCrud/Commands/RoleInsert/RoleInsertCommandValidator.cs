using FluentValidation;

namespace PT.Application.Features.RolesCrud.Commands.RoleInsert
{
    public class RoleInsertCommandValidator : AbstractValidator<RoleInsertCommand>
    {
        public RoleInsertCommandValidator()
        {
            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("El código es requerido.");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("La descripción es requerida");
        }
    }
}
