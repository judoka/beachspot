namespace BeachSpot.Application.Abstraction.Identity;

public interface IPasswordHasher
{
    (string password, string salt) HashPassword(string password);
    bool VerifyHashedPassword(string hashedPassword, string providedPassword, string salt);
}
