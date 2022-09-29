using AutoMapper;
using BeachSpot.Application.Abstraction.Identity;
using BeachSpot.Application.Abstraction.Persistence;
using BeachSpot.Application.Responses;
using BeachSpot.Domain.Entities;
using MediatR;

namespace BeachSpot.Application.Features.Sightings.Commands.LikeSighting;

public class LikeSightingCommandHandler : IRequestHandler<LikeSightingCommand, Response<LikeSightingCommandResponse>>
{
    private readonly ISightingRepository _repository;
    private readonly ISessionService _session;
    private readonly IMapper _mapper;
    public LikeSightingCommandHandler(ISightingRepository repository, ISessionService session, IMapper mapper)
    {
        _repository = repository;
        _session = session;
        _mapper = mapper;
    }

    public async Task<Response<LikeSightingCommandResponse>> Handle(LikeSightingCommand request, CancellationToken cancellationToken)
    {
        var commandResponse = new LikeSightingCommandResponse();

        var validator = new LikeSightingCommandValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Any())
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return Response<LikeSightingCommandResponse>.ValidationFailed(errors);
        }

        var loggedUserId = _session.GetUserId();
        var sighting = await _repository.GetByIdAsync(request.Id);
        if (sighting == null)
        {
            return Response<LikeSightingCommandResponse>.Empty(request.Id.ToString());
        }

        sighting.Likes ??= new List<Like>();

        if (sighting.Likes.Any(l => l.UserId == loggedUserId))
        {
            return Response<LikeSightingCommandResponse>.ValidationFailed("Logged user already liked this sighting!");
        }


        sighting.Likes.Add(new Like { UserId = loggedUserId });

        await _repository.UpdateAsync(sighting);

        return Response<LikeSightingCommandResponse>.Ok(_mapper.Map<LikeSightingCommandResponse>(sighting));
    }
}
