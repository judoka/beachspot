using BeachSpot.Api.Authorization;
using BeachSpot.Application.Features.Beaches.Commands.CreateBeach;
using BeachSpot.Application.Features.Beaches.Queries.GetBeachesList;
using BeachSpot.Application.Features.Beaches.Queries.GetBeachesListListWithSightings;
using BeachSpot.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BeachSpot.Api.Controllers;


[Authorize]
[ApiController]
[Route("beaches")]
public class BeachesController : BaseController
{
    private readonly IMediator _mediator;
    public BeachesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Get all beaches 
    /// </summary>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpGet("all", Name = "GetAllBeaches")]
    [ProducesResponseType(typeof(Response<List<BeachListVm>>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetAllBeaches()
        => HandleResponse(await _mediator.Send(new GetBeachListQuery()));

    /// <summary>
    /// Get all beaches including sightings
    /// </summary>
    /// <returns></returns>    
    [HttpGet("allwithsightings", Name = "GetBeachesInlucudeSightings")]
    [ProducesResponseType(typeof(Response<List<BeachSightingsListVm>>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetBeachesInlucudeSightings()
        => HandleResponse(await _mediator.Send(new GetBeachesListWithSightingsQuery()));

    /// <summary>
    /// Create a new beach
    /// </summary>
    /// <param name="createBeachCommand"></param>
    /// <returns></returns>
    [HttpPost(Name = "AddBeach")]
    [ProducesResponseType(typeof(Response<Response<CreateBeachCommandResponse>>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateBeachCommand createBeachCommand)
        => HandleResponse(await _mediator.Send(createBeachCommand));
}
