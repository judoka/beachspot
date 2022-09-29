using BeachSpot.Application.Abstraction.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace BeachSpot.QuotesRestProvider;

public static class QuotesRestServiceRegistration
{
    public static IServiceCollection AddQuotesRestServices(this IServiceCollection services)
    {
        services.AddScoped<IQuoteProvider, Provider>();
        services.AddHttpClient<Client>();

        return services;
    }
}
