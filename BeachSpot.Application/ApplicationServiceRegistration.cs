using BeachSpot.Application.Abstraction.Identity;
using BeachSpot.Application.Service;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;

namespace BeachSpot.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<ISessionService, SessionService>();
        return services;
    }
}
