using BeachSpot.Application.Responses;
using MediatR;

namespace BeachSpot.Application.Features.Sightings.Commands.DeleteSighting;

public class DeleteSightingCommand : IRequest<Response<DeleteSightingCommandResponse>>
{
    public Guid Id { get; set; }
}
