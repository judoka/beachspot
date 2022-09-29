using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BeachSpot.Persistence;

public class BeachSpotDBContextDesignFactory : IDesignTimeDbContextFactory<BeachSpotDBContext>
{
    public BeachSpotDBContext CreateDbContext(string[] args)
    {
        var apiProjectPath = Directory.GetCurrentDirectory().Replace("BeachSpot.Persistence", "BeachSpot.Api");

        var configuration = new ConfigurationBuilder()
                .SetBasePath(apiProjectPath)
                .AddJsonFile("appsettings.json")
                .Build();

        var connectionString = configuration.GetConnectionString("BeachSpotDBConnectionString");

        var optionsBuilder = new DbContextOptionsBuilder<BeachSpotDBContext>().UseNpgsql(connectionString);

        return new BeachSpotDBContext(optionsBuilder.Options);
    }
}
