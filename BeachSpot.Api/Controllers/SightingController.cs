using BeachSpot.Api.Authorization;
using BeachSpot.Application.Features.Sightings.Commands.CreateSighting;
using BeachSpot.Application.Features.Sightings.Commands.DeleteSighting;
using BeachSpot.Application.Features.Sightings.Commands.LikeSighting;
using BeachSpot.Application.Features.Sightings.Commands.UnlikeSighting;
using BeachSpot.Application.Features.Sightings.Queries.GetSightingDetails;
using BeachSpot.Application.Features.Sightings.Queries.GetSightingsList;
using BeachSpot.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BeachSpot.Api.Controllers;


[Authorize]
[ApiController]
[Route("sighting")]
public class SightingController : BaseController
{
    private readonly IMediator _mediator;
    public SightingController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Get all sightings 
    /// </summary>
    /// <returns></returns>    
    [HttpGet("all", Name = "GetAllSightings")]
    [ProducesResponseType(typeof(Response<List<SightingDetailsVM>>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetAllSightings()
        => HandleResponse(await _mediator.Send(new GetSightingListQuery()));

    /// <summary>
    /// Get sighting by id
    /// </summary>
    /// <returns></returns>    
    [HttpGet("{id}", Name = "GetSightingById")]
    [ProducesResponseType(typeof(Response<SightingDetailsVM>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetSightingById(Guid id)
        => HandleResponse(await _mediator.Send(new GetSightingDetailsQuery { Id = id }));

    /// <summary>
    /// Create a new sighting
    /// </summary>
    /// <param name="createSightingCommand"></param>
    /// <returns></returns>
    [HttpPost(Name = "CreateSighting")]
    [ProducesResponseType(typeof(Response<CreateSightingCommandResponse>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateSightingCommand createSightingCommand)
        => HandleResponse(await _mediator.Send(createSightingCommand));

    /// <summary>
    /// Delete sighting
    /// </summary>
    /// <param name="deleteSightingCommand"></param>
    /// <returns></returns>
    [HttpDelete(Name = "DeleteSighting")]
    [ProducesResponseType(typeof(Response<DeleteSightingCommandResponse>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Delete([FromBody] DeleteSightingCommand deleteSightingCommand)
        => HandleResponse(await _mediator.Send(deleteSightingCommand));


    /// <summary>
    /// Like sighting
    /// </summary>
    /// <param name="likeSightingCommand"></param>
    /// <returns></returns>
    [HttpPost("like", Name = "LikeSighting")]
    [ProducesResponseType(typeof(Response<LikeSightingCommandResponse>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Like([FromBody] LikeSightingCommand likeSightingCommand)
        => HandleResponse(await _mediator.Send(likeSightingCommand));

    /// <summary>
    /// Unlike sighting
    /// </summary>
    /// <param name="unlikeSightingCommand"></param>
    /// <returns></returns>
    [HttpDelete("unlike", Name = "UnlikeSighting")]
    [ProducesResponseType(typeof(Response<UnlikeSightingCommandResponse>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Like([FromBody] UnlikeSightingCommand unlikeSightingCommand)
        => HandleResponse(await _mediator.Send(unlikeSightingCommand));
}
