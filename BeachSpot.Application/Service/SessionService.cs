using BeachSpot.Application.Abstraction.Identity;
using BeachSpot.Application.Models.Authentication;

namespace BeachSpot.Application.Service;

public class SessionService : ISessionService
{
    private AuthenticatedUser _authenticatedUser;
    public AuthenticatedUser Get() => _authenticatedUser;

    public Guid GetUserId() => _authenticatedUser.Id;

    public void Set(AuthenticatedUser user)
    {
        _authenticatedUser = user ?? throw new ArgumentNullException(nameof(user));
    }
}
