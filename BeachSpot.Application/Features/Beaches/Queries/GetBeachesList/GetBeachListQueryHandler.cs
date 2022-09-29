using AutoMapper;
using BeachSpot.Application.Abstraction.Persistence;
using BeachSpot.Application.Features.Beaches.Queries.GetBeachesList;
using BeachSpot.Application.Responses;
using MediatR;

namespace BeachSpot.Application.Features.FlowBeachesers.Queries.GetBeachesList;

public class GetBeachListQueryHandler : IRequestHandler<GetBeachListQuery, Response<List<BeachListVm>>>
{
    private readonly IBeachRepository _repository;
    private readonly IMapper _mapper;

    public GetBeachListQueryHandler(IMapper mapper, IBeachRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Response<List<BeachListVm>>> Handle(GetBeachListQuery request, CancellationToken cancellationToken)
    {
        var list = (await _repository.GetAllAsync()).OrderBy(f => f.Name);
        if (!list.Any())
        {
            return Response<List<BeachListVm>>.Empty("Beaches");
        }

        return Response<List<BeachListVm>>.Ok(_mapper.Map<List<BeachListVm>>(list));
    }
}
