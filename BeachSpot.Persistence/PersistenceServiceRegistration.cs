using BeachSpot.Application.Abstraction.Persistence;
using BeachSpot.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BeachSpot.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BeachSpotDBContext>(options
            => options.UseNpgsql(configuration.GetConnectionString("BeachSpotDBConnectionString")));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IBeachRepository, BeachRepository>();
        services.AddScoped<ISightingRepository, SightingRepository>();
        return services;
    }
}
