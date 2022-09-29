using BeachSpot.Domain.Entities;
using BeachSpot.Persistence.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace BeachSpot.Persistence;

public class BeachSpotDBContext : DbContext
{
    public BeachSpotDBContext(DbContextOptions<BeachSpotDBContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Beach> Beaches { get; set; }
    public DbSet<Sighting> Sightings { get; set; }
    public DbSet<Like> Likes { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new UserEntityTypeConfiguration());
        builder.ApplyConfiguration(new BeachEntityTypeConfiguration());
        builder.ApplyConfiguration(new LikeEntityTypeConfiguration());
        builder.ApplyConfiguration(new SightingEntityTypeConfiguration());
    }
}
