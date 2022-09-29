using BeachSpot.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace BeachSpot.Persistence.IntegrationTests;

public class BeachRepositoryTests
{

    private readonly BeachSpotDBContext _beachSpotDBContext;
    private readonly BeachRepository _repository;
    public BeachRepositoryTests()
    {
        var dbContextOptions = new DbContextOptionsBuilder<BeachSpotDBContext>()
            .UseInMemoryDatabase("I nMemoryDatabase").Options;
        _beachSpotDBContext = new BeachSpotDBContext(dbContextOptions);
        _beachSpotDBContext.Database.EnsureCreated();
        _repository = new BeachRepository(_beachSpotDBContext);
    }

    [Fact]
    public async void HasAnyBeach()
    {
        var result = await _repository.GetAllAsync();
        Assert.NotNull(result);
        Assert.True(result.Any());
    }
}