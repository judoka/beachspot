using AutoMapper;
using BeachSpot.Application.Abstraction.Identity;
using BeachSpot.Application.Abstraction.Persistence;
using BeachSpot.Application.Responses;
using MediatR;

namespace BeachSpot.Application.Features.Sightings.Commands.UnlikeSighting;

public class UnlikeSightingCommandHandler : IRequestHandler<UnlikeSightingCommand, Response<UnlikeSightingCommandResponse>>
{
    private readonly ISightingRepository _repository;
    private readonly ISessionService _session;
    private readonly IMapper _mapper;

    public UnlikeSightingCommandHandler(ISightingRepository repository, ISessionService session, IMapper mapper)
    {
        _repository = repository;
        _session = session;
        _mapper = mapper;
    }

    public async Task<Response<UnlikeSightingCommandResponse>> Handle(UnlikeSightingCommand request, CancellationToken cancellationToken)
    {
        var commandResponse = new UnlikeSightingCommandResponse();

        var validator = new UnlikeSightingCommandValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Any())
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return Response<UnlikeSightingCommandResponse>.ValidationFailed(errors);
        }

        var loggedUserId = _session.GetUserId();
        var sighting = await _repository.GetByIdAsync(request.Id);
        if (sighting == null)
        {
            return Response<UnlikeSightingCommandResponse>.Empty(request.Id.ToString());
        }

        if (sighting.Likes == null || !sighting.Likes.Any())
        {
            return Response<UnlikeSightingCommandResponse>.ValidationFailed($"Sighting '{request.Id}' doesn't have any likes!");
        }

        var like = sighting.Likes.SingleOrDefault(l => l.UserId == loggedUserId);
        if (like == null)
        {
            return Response<UnlikeSightingCommandResponse>.ValidationFailed("Only user who liked sighting can unlike it!");
        }

        sighting.Likes.Remove(like);

        await _repository.UpdateAsync(sighting);

        return Response<UnlikeSightingCommandResponse>.Ok(_mapper.Map<UnlikeSightingCommandResponse>(sighting));
    }
}
