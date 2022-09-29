namespace BeachSpot.Application.Models.Authentication;

public class AuthenticatedUser
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
}
