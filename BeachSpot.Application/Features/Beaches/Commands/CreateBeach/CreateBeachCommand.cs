using BeachSpot.Application.Responses;
using MediatR;

namespace BeachSpot.Application.Features.Beaches.Commands.CreateBeach;
public class CreateBeachCommand : IRequest<Response<CreateBeachCommandResponse>>
{
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
}

