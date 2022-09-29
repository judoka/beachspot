using BeachSpot.Application.Models.Authentication;

namespace BeachSpot.Application.Abstraction.Identity;

public interface ISessionService
{
    AuthenticatedUser Get();
    void Set(AuthenticatedUser user);
    Guid GetUserId();
}
