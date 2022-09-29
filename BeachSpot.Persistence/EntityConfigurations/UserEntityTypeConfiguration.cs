using BeachSpot.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeachSpot.Persistence.EntityConfigurations;

public class UserEntityTypeConfiguration : BaseEntityTypeConfiguration<User>
{
    protected override string Table => "Users";

    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);
        builder.Property(u => u.Username).HasMaxLength(50);
        builder.Property(u => u.Password).HasMaxLength(50);
        builder.Property(u => u.Email).HasMaxLength(50);
        builder.Property(u => u.Salt).HasMaxLength(100);
    }
}
