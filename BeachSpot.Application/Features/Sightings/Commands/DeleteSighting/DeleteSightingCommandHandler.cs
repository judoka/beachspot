using BeachSpot.Application.Abstraction.Identity;
using BeachSpot.Application.Abstraction.Persistence;
using BeachSpot.Application.Responses;
using MediatR;

namespace BeachSpot.Application.Features.Sightings.Commands.DeleteSighting;

public class DeleteSightingCommandHandler : IRequestHandler<DeleteSightingCommand, Response<DeleteSightingCommandResponse>>
{
    private readonly ISightingRepository _repository;
    private readonly ISessionService _session;
    public DeleteSightingCommandHandler(ISightingRepository repository, ISessionService session)
    {
        _repository = repository;
        _session = session;
    }

    public async Task<Response<DeleteSightingCommandResponse>> Handle(DeleteSightingCommand request, CancellationToken cancellationToken)
    {
        var commandResponse = new DeleteSightingCommandResponse();

        var validator = new DeleteSightingCommandValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Any())
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return Response<DeleteSightingCommandResponse>.ValidationFailed(errors);
        }

        var loggedUserId = _session.GetUserId();
        var sighting = await _repository.GetByIdAsync(request.Id);
        if (sighting == null)
        {
            return Response<DeleteSightingCommandResponse>.Empty(request.Id.ToString());
        }

        if (sighting.UserId != loggedUserId)
        {
            return Response<DeleteSightingCommandResponse>.ValidationFailed("Only user who created sighting can delete it!");
        }

        await _repository.DeleteAsync(sighting);

        var response = new DeleteSightingCommandResponse { Ok = true };
        return Response<DeleteSightingCommandResponse>.Ok(response);
    }
}
