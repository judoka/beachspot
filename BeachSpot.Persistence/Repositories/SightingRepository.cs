using BeachSpot.Application.Abstraction.Persistence;
using BeachSpot.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BeachSpot.Persistence.Repositories;

public class SightingRepository : Repository<Sighting>, ISightingRepository
{
    public SightingRepository(BeachSpotDBContext dbContext) : base(dbContext) { }

    public override IQueryable<Sighting> Query
        => _dbContext.Sightings
        .Include(s => s.User)
        .Include(s => s.Beach)
        .Include(s => s.Likes)
        .ThenInclude(l => l.User);
}
