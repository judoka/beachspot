using BeachSpot.Application.Abstraction.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace BeachSpot.QuotesRestProvider.IntegrationTests;
public class ProviderTests
{

    private readonly IQuoteProvider _quotesProvider;
    public ProviderTests()
    {
        var services = new ServiceCollection();
        services.AddQuotesRestServices();

        using var serviceProvider = services.BuildServiceProvider();
        _quotesProvider = serviceProvider.GetRequiredService<IQuoteProvider>();
    }

    [Fact]
    public async void TestDailyQuote()
    {
        var result = await _quotesProvider.GetQuoteOfTheDay();
        Assert.NotNull(result);
        Assert.True(result.Length > 0);
    }
}