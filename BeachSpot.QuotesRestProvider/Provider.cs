using BeachSpot.Application.Abstraction.Infrastructure;

namespace BeachSpot.QuotesRestProvider;

public class Provider : IQuoteProvider
{
    private readonly Client _client;
    public Provider(Client client)
    {
        _client = client;
    }


    public async Task<string> GetQuoteOfTheDay()
    {
        var response = await _client.GetQuoteOfTheDay();
        return response?.Contents?.Quotes?.FirstOrDefault()?.Quote;
    }
}