using BeachSpot.Domain.Entities;
using BeachSpot.Persistence;
namespace BeachSpot.API.IntergrationTests.Base;

public class Utilities
{
    public static void InitializeDbForTests(BeachSpotDBContext context)
    {
        context.Beaches.Add(new Beach
        {
            Id = Guid.NewGuid(),
            Name = "Beach 1",
            Description = "Beach 1 description",
            ImageUrl = "Beach 1 image url"
        });

        context.Beaches.Add(new Beach
        {
            Id = Guid.NewGuid(),
            Name = "Beach 2",
            Description = "Beach 2 description",
            ImageUrl = "Beach 2 image url"
        });

        context.Beaches.Add(new Beach
        {
            Id = Guid.NewGuid(),
            Name = "Beach 3",
            Description = "Beach 3 description",
            ImageUrl = "Beach 3 image url"
        });

        context.Beaches.Add(new Beach
        {
            Id = Guid.NewGuid(),
            Name = "Beach 4",
            Description = "Beach 4 description",
            ImageUrl = "Beach 4 image url"
        });

        context.SaveChanges();
    }
}
