using BeachSpot.API.IntergrationTests.Base;
using BeachSpot.Application.Features.Beaches.Queries.GetBeachesList;
using BeachSpot.Application.Responses;
using Newtonsoft.Json;
using Xunit;

namespace BeachSpot.API.IntergrationTests.Controllers;

public class FowersControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly CustomWebApplicationFactory<Program> _factory;

    public FowersControllerTests(CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task ReturnsSuccessResult()
    {
        var client = _factory.GetAnonymousClient();

        var response = await client.GetAsync("/beaches/all");

        response.EnsureSuccessStatusCode();

        var responseString = await response.Content.ReadAsStringAsync();

        var result = JsonConvert.DeserializeObject<Response<List<BeachListVm>>>(responseString);

        Assert.IsType<Response<List<BeachListVm>>>(result);
        Assert.True(result.Data.Any());
    }
}
