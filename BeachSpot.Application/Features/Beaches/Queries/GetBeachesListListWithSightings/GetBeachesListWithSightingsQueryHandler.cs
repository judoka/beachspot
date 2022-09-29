using AutoMapper;
using BeachSpot.Application.Abstraction.Persistence;
using BeachSpot.Application.Responses;
using MediatR;

namespace BeachSpot.Application.Features.Beaches.Queries.GetBeachesListListWithSightings;

public class GetBeachesListWithSightingsQueryHandler : IRequestHandler<GetBeachesListWithSightingsQuery, Response<List<BeachSightingsListVm>>>
{
    private readonly IMapper _mapper;
    private readonly IBeachRepository _repository;

    public GetBeachesListWithSightingsQueryHandler(IMapper mapper, IBeachRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Response<List<BeachSightingsListVm>>> Handle(GetBeachesListWithSightingsQuery request, CancellationToken cancellationToken)
    {
        var list = await _repository.GetAllAsync();
        if (list == null || !list.Any())
        {
            return Response<List<BeachSightingsListVm>>.Empty("Beaches");
        }

        return Response<List<BeachSightingsListVm>>.Ok(_mapper.Map<List<BeachSightingsListVm>>(list));
    }
}
