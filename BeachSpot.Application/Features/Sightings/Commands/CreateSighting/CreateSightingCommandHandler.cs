using AutoMapper;
using BeachSpot.Application.Abstraction.Identity;
using BeachSpot.Application.Abstraction.Infrastructure;
using BeachSpot.Application.Abstraction.Persistence;
using BeachSpot.Application.Responses;
using BeachSpot.Domain.Entities;
using MediatR;

namespace BeachSpot.Application.Features.Sightings.Commands.CreateSighting;

public class CreateSightingCommandHandler : IRequestHandler<CreateSightingCommand, Response<CreateSightingCommandResponse>>
{
    private readonly ISightingRepository _repository;
    private readonly IMapper _mapper;
    private readonly ISessionService _session;
    private readonly IQuoteProvider _quoteProvider;
    public CreateSightingCommandHandler(IMapper mapper, ISightingRepository repository,
        ISessionService session, IQuoteProvider quoteProvider)
    {
        _mapper = mapper;
        _repository = repository;
        _session = session;
        _quoteProvider = quoteProvider;
    }

    public async Task<Response<CreateSightingCommandResponse>> Handle(CreateSightingCommand request, CancellationToken cancellationToken)
    {
        var commandResponse = new CreateSightingCommandResponse();

        var validator = new CreateSightingCommandValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Any())
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return Response<CreateSightingCommandResponse>.ValidationFailed(errors);
        }

        var entity = _mapper.Map<Sighting>(request);
        entity.Quote = await _quoteProvider.GetQuoteOfTheDay();
        entity.UserId = _session.GetUserId();
        
        var newSighting = await _repository.AddAsync(entity);

        return Response<CreateSightingCommandResponse>.Ok(_mapper.Map<CreateSightingCommandResponse>(newSighting));
    }
}
