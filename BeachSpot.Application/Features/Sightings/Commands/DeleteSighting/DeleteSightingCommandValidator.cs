using FluentValidation;

namespace BeachSpot.Application.Features.Sightings.Commands.DeleteSighting;

public class DeleteSightingCommandValidator : AbstractValidator<DeleteSightingCommand>
{
    public DeleteSightingCommandValidator()
    {        
        RuleFor(p => p.Id).NotEmpty().WithMessage("{PropertyName} is required.");
    }
}
