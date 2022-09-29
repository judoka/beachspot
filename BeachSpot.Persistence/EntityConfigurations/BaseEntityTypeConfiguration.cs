using BeachSpot.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeachSpot.Persistence.EntityConfigurations;

public abstract class BaseEntityTypeConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity, IEntity
{
    protected abstract string Table { get; }

    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.ToTable(Table);
        builder.HasKey(e => e.Id);
    }
}
