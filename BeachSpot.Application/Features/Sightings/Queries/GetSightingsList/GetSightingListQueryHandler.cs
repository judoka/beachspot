using AutoMapper;
using BeachSpot.Application.Abstraction.Persistence;
using BeachSpot.Application.Responses;
using MediatR;

namespace BeachSpot.Application.Features.Sightings.Queries.GetSightingsList;

public class GetSightingListQueryHandler : IRequestHandler<GetSightingListQuery, Response<List<SightingListVm>>>
{
    private readonly ISightingRepository _repository;
    private readonly IMapper _mapper;

    public GetSightingListQueryHandler(IMapper mapper, ISightingRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Response<List<SightingListVm>>> Handle(GetSightingListQuery request, CancellationToken cancellationToken)
    {
        var list = (await _repository.GetAllAsync()).OrderBy(s => s.Beach.Id);
        if (!list.Any())
        {
            return Response<List<SightingListVm>>.Empty("Sightings");
        }

        return Response<List<SightingListVm>>.Ok(_mapper.Map<List<SightingListVm>>(list));
    }
}
