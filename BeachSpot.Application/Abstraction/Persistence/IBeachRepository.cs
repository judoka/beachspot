using BeachSpot.Domain.Entities;

namespace BeachSpot.Application.Abstraction.Persistence;

public interface IBeachRepository : IRepository<Beach>
{
    Task<Beach?> GetByNameAsync(string name);
}
