using FluentValidation;

namespace BeachSpot.Application.Features.Sightings.Commands.CreateSighting;

public class CreateSightingCommandValidator : AbstractValidator<CreateSightingCommand>
{
    public CreateSightingCommandValidator()
    {
        RuleFor(p => p.Latitude)
            .MaximumLength(30).WithMessage("{PropertyName} must not exceed 30 characters.");
        RuleFor(p => p.Longitude)
            .MaximumLength(30).WithMessage("{PropertyName} must not exceed 30 characters.");

        RuleFor(p => p.ImageUrl)
           .NotEmpty().WithMessage("{PropertyName} is required.")
           .NotNull()
           .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
        
        RuleFor(p => p.BeachId).NotEmpty().WithMessage("{PropertyName} is required.");
    }
}
