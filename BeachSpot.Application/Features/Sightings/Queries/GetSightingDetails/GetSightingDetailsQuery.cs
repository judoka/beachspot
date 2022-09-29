using BeachSpot.Application.Responses;
using MediatR;

namespace BeachSpot.Application.Features.Sightings.Queries.GetSightingDetails;

public class GetSightingDetailsQuery : IRequest<Response<SightingDetailsVM>>
{
    public Guid Id { get; set; }
}
