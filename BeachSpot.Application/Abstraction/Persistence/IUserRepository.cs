using BeachSpot.Domain.Entities;

namespace BeachSpot.Application.Abstraction.Persistence;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByUsername(string username);
}
