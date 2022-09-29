using FluentValidation;

namespace BeachSpot.Application.Features.Sightings.Commands.LikeSighting;

public class LikeSightingCommandValidator : AbstractValidator<LikeSightingCommand>
{
    public LikeSightingCommandValidator()
    {        
        RuleFor(p => p.Id).NotEmpty().WithMessage("{PropertyName} is required.");
    }
}
