using BeachSpot.Application.Service;
using Xunit;

namespace BeachSpot.Persistence.UnitTests;

public class PasswordHasherTests
{
    private readonly PasswordHasher _passwordHasher;

    public PasswordHasherTests()
    {
        _passwordHasher = new PasswordHasher();
    }

    [Fact]
    public void Test_Hash_Verification()
    {
        var plainTextPassword = "test";
        
        var hashed = _passwordHasher.HashPassword(plainTextPassword);
        var hashedPassword = hashed.password;
        var salt = hashed.salt;

        var verified = _passwordHasher.VerifyHashedPassword(hashedPassword, plainTextPassword, salt);
        
        Assert.True(verified);
    }
}