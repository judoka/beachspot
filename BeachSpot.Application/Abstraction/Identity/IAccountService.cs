using BeachSpot.Application.Models.Authentication;
using BeachSpot.Application.Responses;

namespace BeachSpot.Application.Abstraction.Identity;

public interface IAccountService
{
    Task<Response<AuthenticatedUser>> AuthenticateAsync(AuthenticationRequest request);
    Task<Response<AuthenticatedUser>> RegisterAsync(RegistrationRequest request);
}
