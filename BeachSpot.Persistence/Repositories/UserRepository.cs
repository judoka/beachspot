using BeachSpot.Application.Abstraction.Persistence;
using BeachSpot.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BeachSpot.Persistence.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(BeachSpotDBContext dbContext) : base(dbContext) { }

    public override IQueryable<User> Query
        => _dbContext.Users
        .Include(u => u.Likes)
        .ThenInclude(l => l.Sighting)
        .ThenInclude(s => s.Beach);

    public async Task<User?> GetByUsername(string username)
        => await Query.SingleOrDefaultAsync(u => u.Username.ToLower() == username.Trim().ToLower());
}
