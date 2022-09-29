using Microsoft.Net.Http.Headers;
using System.Net.Http.Json;

namespace BeachSpot.QuotesRestProvider;

public class Client
{
    private readonly HttpClient _httpClient;

    public Client(HttpClient httpClient)
    {
        _httpClient = httpClient;

        _httpClient.BaseAddress = new Uri("https://quotes.rest/");

        _httpClient.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");

    }

    internal async Task<Response> GetQuoteOfTheDay() =>
        await _httpClient.GetFromJsonAsync<Response>("qod?language=en");
}
