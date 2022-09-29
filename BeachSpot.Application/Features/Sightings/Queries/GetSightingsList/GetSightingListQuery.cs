using BeachSpot.Application.Responses;
using MediatR;

namespace BeachSpot.Application.Features.Sightings.Queries.GetSightingsList;

public class GetSightingListQuery : IRequest<Response<List<SightingListVm>>> { }
