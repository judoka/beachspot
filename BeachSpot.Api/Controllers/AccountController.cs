using BeachSpot.Api.Authorization;
using BeachSpot.Application.Abstraction.Identity;
using BeachSpot.Application.Models.Authentication;
using BeachSpot.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BeachSpot.Api.Controllers;


[Authorize]
[ApiController]
[Route("account")]
public class AccountController : BaseController
{
    private IAccountService _service;

    public AccountController(IAccountService service)
    {
        _service = service;
    }


    /// <summary>
    /// Register new user
    /// </summary>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpPost]
    [Route("register")]
    [ProducesResponseType(typeof(Response<AuthenticatedUser>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Register([FromBody] RegistrationRequest request)
        => HandleResponse(await _service.RegisterAsync(request));
}