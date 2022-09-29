using BeachSpot.Application.Responses;
using MediatR;

namespace BeachSpot.Application.Features.Beaches.Queries.GetBeachesList;

public class GetBeachListQuery : IRequest<Response<List<BeachListVm>>> { }
