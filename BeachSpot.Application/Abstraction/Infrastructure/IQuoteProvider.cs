namespace BeachSpot.Application.Abstraction.Infrastructure;

public interface IQuoteProvider
{
    Task<string> GetQuoteOfTheDay();
}
