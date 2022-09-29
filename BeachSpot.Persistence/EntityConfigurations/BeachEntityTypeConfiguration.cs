using BeachSpot.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeachSpot.Persistence.EntityConfigurations;

public class BeachEntityTypeConfiguration : BaseEntityTypeConfiguration<Beach>
{
    protected override string Table => "Beaches";

    public override void Configure(EntityTypeBuilder<Beach> builder)
    {
        base.Configure(builder);
        builder.Property(f => f.Name).HasMaxLength(50);
        builder.Property(f => f.ImageUrl).HasMaxLength(200);
        builder.Property(f => f.Description).HasMaxLength(1000);
        builder.HasData(BeachesToSeed);
    }

    private static IEnumerable<Beach> BeachesToSeed =>
        new List<Beach> {
        new Beach { Id = Guid.NewGuid(), Name = "Copacabana", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/6/62/Praia_de_Copacabana_-_Rio_de_Janeiro%2C_Brasil.jpg", Description = "Copacabana (Portuguese pronunciation: [kɔpakaˈbɐ̃nɐ]) is a bairro (neighbourhood) located in the South Zone of the city of Rio de Janeiro, Brazil. It is most prominently known for its 4 km (2.5 miles) balneario beach, which is one of the most famous in the world." },
        new Beach { Id = Guid.NewGuid(), Name = "Venice", ImageUrl = "https://en.wikipedia.org/wiki/File:Beach_bikepath_in_the_Venice_Beach_park,_California.jpg", Description = "Venice is a neighborhood of the city of Los Angeles within the Westside region of Los Angeles County, California." },
        new Beach { Id = Guid.NewGuid(), Name = "Zlatni Rat", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/1c/Golden_Cape.jpg/260px-Golden_Cape.jpg", Description = "The Zlatni Rat, often referred to as the Golden Cape or Golden Horn (translated from the local Chakavian dialect), is a spit of land located about 2 kilometres (1 mile) west from the harbour town of Bol on the southern coast of the Croatian island of Brač, in the region of Dalmatia." }    };
}
