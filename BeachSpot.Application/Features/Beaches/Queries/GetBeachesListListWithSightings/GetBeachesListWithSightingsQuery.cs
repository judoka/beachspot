using BeachSpot.Application.Responses;
using MediatR;

namespace BeachSpot.Application.Features.Beaches.Queries.GetBeachesListListWithSightings;

public class GetBeachesListWithSightingsQuery : IRequest<Response<List<BeachSightingsListVm>>> { }
