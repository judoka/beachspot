using FluentValidation;

namespace BeachSpot.Application.Features.Sightings.Commands.UnlikeSighting;

public class UnlikeSightingCommandValidator : AbstractValidator<UnlikeSightingCommand>
{
    public UnlikeSightingCommandValidator()
    {        
        RuleFor(p => p.Id).NotEmpty().WithMessage("{PropertyName} is required.");
    }
}
