using BeachSpot.Application.Abstraction.Persistence;
using BeachSpot.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BeachSpot.Persistence.Repositories;

public class BeachRepository : Repository<Beach>, IBeachRepository
{
    public BeachRepository(BeachSpotDBContext dbContext) : base(dbContext) { }
    public override IQueryable<Beach> Query 
        => _dbContext.Beaches.Include(f => f.Sightings).ThenInclude(s => s.User);

    public Task<Beach?> GetByNameAsync(string name)
        => _dbContext.Beaches.SingleOrDefaultAsync(f => f.Name.ToLower() == name.ToLower());
}
