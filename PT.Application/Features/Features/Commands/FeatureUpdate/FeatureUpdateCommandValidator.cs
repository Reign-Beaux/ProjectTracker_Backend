using FluentValidation;

namespace PT.Application.Features.Features.Commands.FeatureUpdate
{
    public class FeatureUpdateCommandValidator : AbstractValidator<FeatureUpdateCommand>
    {
        public FeatureUpdateCommandValidator()
        {
            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("El código es requerido.");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("La descripción es requerida");
            RuleFor(x => x.Path)
                .NotEmpty().WithMessage("El path es requerido");
        }
    }
}
