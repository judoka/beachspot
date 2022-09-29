using BeachSpot.Application.Responses;
using MediatR;

namespace BeachSpot.Application.Features.Sightings.Commands.UnlikeSighting;

public class UnlikeSightingCommand : IRequest<Response<UnlikeSightingCommandResponse>>
{
    public Guid Id { get; set; }
}
