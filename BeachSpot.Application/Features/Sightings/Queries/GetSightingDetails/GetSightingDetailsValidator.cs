using FluentValidation;

namespace BeachSpot.Application.Features.Sightings.Queries.GetSightingDetails;

public class GetSightingDetailsValidator : AbstractValidator<GetSightingDetailsQuery>
{
    public GetSightingDetailsValidator()
    {        
        RuleFor(p => p.Id).NotEmpty().WithMessage("{PropertyName} is required.");
    }
}
