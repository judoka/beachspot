namespace BeachSpot.Application.Models.Authentication;

public class RegistrationRequest : AuthenticationRequest
{
    public string? Email { get; set; }
}
