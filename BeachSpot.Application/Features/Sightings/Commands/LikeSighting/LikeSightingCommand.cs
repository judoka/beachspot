using BeachSpot.Application.Responses;
using MediatR;

namespace BeachSpot.Application.Features.Sightings.Commands.LikeSighting;

public class LikeSightingCommand : IRequest<Response<LikeSightingCommandResponse>>
{
    public Guid Id { get; set; }
}
