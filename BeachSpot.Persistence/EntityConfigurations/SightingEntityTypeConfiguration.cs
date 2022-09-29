using BeachSpot.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeachSpot.Persistence.EntityConfigurations;

public class SightingEntityTypeConfiguration : BaseEntityTypeConfiguration<Sighting>
{
    protected override string Table => "Sightings";

    public override void Configure(EntityTypeBuilder<Sighting> builder)
    {
        base.Configure(builder);
        builder.Property(s => s.Latitude).HasMaxLength(30);
        builder.Property(s => s.Longitude).HasMaxLength(30);
        builder.Property(s => s.Quote).HasMaxLength(1000);
        builder.Property(s => s.ImageUrl).HasMaxLength(200);
        builder.HasOne(s => s.User).WithMany().HasForeignKey(s => s.UserId);
        builder.HasOne(s => s.Beach).WithMany(f => f.Sightings).HasForeignKey(s => s.BeachId);        
    }
}
