namespace BeachSpot.Application.Models.Authentication;

public class AuthenticationRequest
{
    public string? Username { get; set; }
    public string? Password { get; set; }

    //This needs to be done because the PostgreSQL is a case-sensitive database by default
    public string UsernameSafe
    {
        get
        {
            if (string.IsNullOrEmpty(Username))
            {
                return string.Empty;
            }

            return Username.Trim().ToLower();
        }
    }

    //This needs to be done because the PostgreSQL is a case-sensitive database by default
    public string PasswordSafe
    {
        get
        {
            if (string.IsNullOrEmpty(Password))
            {
                return string.Empty;
            }

            return Password.Trim().ToLower();
        }
    }
}
