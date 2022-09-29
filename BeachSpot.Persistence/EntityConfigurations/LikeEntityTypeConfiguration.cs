using BeachSpot.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeachSpot.Persistence.EntityConfigurations;

public class LikeEntityTypeConfiguration : BaseEntityTypeConfiguration<Like>
{
    protected override string Table => "Likes";

    public override void Configure(EntityTypeBuilder<Like> builder)
    {
        base.Configure(builder);
        builder.HasOne(l => l.User).WithMany(u => u.Likes).HasForeignKey(l => l.UserId);
        builder.HasOne(l => l.Sighting).WithMany(s => s.Likes).HasForeignKey(l => l.SightingId).OnDelete(DeleteBehavior.Cascade);
    }
}
