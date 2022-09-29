using BeachSpot.Application.Responses;
using MediatR;

namespace BeachSpot.Application.Features.Sightings.Commands.CreateSighting;
public class CreateSightingCommand : IRequest<Response<CreateSightingCommandResponse>>
{
    public string? Longitude { get; set; }
    public string? Latitude { get; set; }
    public Guid BeachId { get; set; }
    public string ImageUrl { get; set; }
}

