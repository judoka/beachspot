using FluentValidation;

namespace BeachSpot.Application.Features.Beaches.Commands.CreateBeach;

public class CreateBeachCommandValidator : AbstractValidator<CreateBeachCommand>
{
    public CreateBeachCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

        RuleFor(p => p.ImageUrl)
           .NotEmpty().WithMessage("{PropertyName} is required.")
           .NotNull()
           .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

        RuleFor(p => p.Description)
           .NotEmpty().WithMessage("{PropertyName} is required.")
           .NotNull()
           .MaximumLength(1000).WithMessage("{PropertyName} must not exceed 1000 characters.");
    }
}
