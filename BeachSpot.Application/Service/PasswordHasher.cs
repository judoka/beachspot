using BeachSpot.Application.Abstraction.Identity;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace BeachSpot.Application.Service;

public class PasswordHasher : IPasswordHasher
{
    private byte[] GenerateSalt() => RandomNumberGenerator.GetBytes(128 / 8);

    //Aware that the KeyDerivation.Pbkdf2 implementation is low secured and not recommended for the real word cases but for this demonstration it's good enough.
    private string Hash(string password, byte[] salt)
    {
        return Convert.ToBase64String(KeyDerivation.Pbkdf2(
               password: password!,
               salt: salt,
               prf: KeyDerivationPrf.HMACSHA256,
               iterationCount: 100000,
               numBytesRequested: 256 / 8));
    }

    public (string password, string salt) HashPassword(string password)
    {
        var salt = GenerateSalt();
        var hashed = Hash(password, salt);
        return (hashed, Convert.ToBase64String(salt));
    }

    public bool VerifyHashedPassword(string hashedPassword, string providedPassword, string salt)
    {
        var hashed = Hash(providedPassword,Convert.FromBase64String(salt));
        return hashed.Equals(hashedPassword);
    }
}
