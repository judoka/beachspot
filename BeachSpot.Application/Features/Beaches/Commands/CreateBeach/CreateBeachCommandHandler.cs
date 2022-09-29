using AutoMapper;
using BeachSpot.Application.Abstraction.Persistence;
using BeachSpot.Application.Responses;
using BeachSpot.Domain.Entities;
using MediatR;

namespace BeachSpot.Application.Features.Beaches.Commands.CreateBeach;

public class CreateBeachCommandHandler : IRequestHandler<CreateBeachCommand, Response<CreateBeachCommandResponse>>
{
    private readonly IBeachRepository _repository;
    private readonly IMapper _mapper;

    public CreateBeachCommandHandler(IMapper mapper, IBeachRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Response<CreateBeachCommandResponse>> Handle(CreateBeachCommand request, CancellationToken cancellationToken)
    {
        var commandResponse = new CreateBeachCommandResponse();

        var validator = new CreateBeachCommandValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Any())
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return Response<CreateBeachCommandResponse>.ValidationFailed(errors);
        }

        var name = request.Name.Trim();
        var existingBeach = await _repository.GetByNameAsync(name);
        if (existingBeach != null)
        {
            return Response<CreateBeachCommandResponse>.ValidationFailed($"Beach named '{name}' already exists!");
        }

        var newBeach = await _repository.AddAsync(_mapper.Map<Beach>(request));

        return Response<CreateBeachCommandResponse>.Ok(_mapper.Map<CreateBeachCommandResponse>(newBeach));
    }
}
