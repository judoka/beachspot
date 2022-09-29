using BeachSpot.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BeachSpot.Persistence.Repositories;

public class LikeRepository : Repository<Like>
{
    public LikeRepository(BeachSpotDBContext dbContext) : base(dbContext) { }
    public override IQueryable<Like> Query => _dbContext.Likes.Include(l => l.User).Include(l => l.Sighting);
}
