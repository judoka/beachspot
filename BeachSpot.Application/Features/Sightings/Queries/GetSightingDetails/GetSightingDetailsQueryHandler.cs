using AutoMapper;
using BeachSpot.Application.Abstraction.Persistence;
using BeachSpot.Application.Responses;
using MediatR;

namespace BeachSpot.Application.Features.Sightings.Queries.GetSightingDetails;

public class GetSightingDetailsQueryHandler : IRequestHandler<GetSightingDetailsQuery, Response<SightingDetailsVM>>
{
    private readonly ISightingRepository _repository;
    private readonly IMapper _mapper;

    public GetSightingDetailsQueryHandler(IMapper mapper, ISightingRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Response<SightingDetailsVM>> Handle(GetSightingDetailsQuery request, CancellationToken cancellationToken)
    {
        var validator = new GetSightingDetailsValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Any())
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return Response<SightingDetailsVM>.ValidationFailed(errors);
        }

        var sighting = await _repository.GetByIdAsync(request.Id);
        if (sighting == null)
        {
            return Response<SightingDetailsVM>.Empty(request.Id.ToString());
        }

        return Response<SightingDetailsVM>.Ok(_mapper.Map<SightingDetailsVM>(sighting));
    }
}
