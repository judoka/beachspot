using BeachSpot.Domain.Entities;

namespace BeachSpot.Application.Abstraction.Persistence;

public interface IRepository<T> where T : class, IEntity
{
    IQueryable<T> Query { get; }
    Task<T?> GetByIdAsync(Guid id);
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<T?> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<IReadOnlyList<T>> GetPagedReponseAsync(int page, int size);
}
