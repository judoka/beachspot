using BeachSpot.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BeachSpot.Api.Controllers;

public class BaseController : ControllerBase
{
    protected IActionResult HandleResponse<T>(Response<T> response) where T : class
    {
        switch (response.Status)
        {
            case Status.OK:
                return Ok(response);

            case Status.VALIDATION_FAILED:
                return BadRequest(response.Errors);

            case Status.EMPTY_RESULT:
                return NotFound(response.Errors?.First() ?? "Resource not found!");

            case Status.INTERNAL_ERROR:
                return Content("Something went wrong!");

            default:
                return Content("Unknown error!"); ;
        }
    }
}
