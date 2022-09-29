using BeachSpot.Application.Abstraction.Persistence;
using BeachSpot.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BeachSpot.Persistence.Repositories;

public abstract class Repository<T> : IRepository<T> where T : class, IEntity
{
    protected readonly BeachSpotDBContext _dbContext;
    public abstract IQueryable<T> Query { get; }
    public Repository(BeachSpotDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<T?> GetByIdAsync(Guid id) => await Query.SingleOrDefaultAsync(e => e.Id == id);

    public async Task<IReadOnlyList<T>> GetAllAsync() => await Query.AsNoTracking().ToListAsync();

    public async virtual Task<IReadOnlyList<T>> GetPagedReponseAsync(int page, int size)
        => await Query.Skip((page - 1) * size).Take(size).AsNoTracking().ToListAsync();

    public async Task<T?> AddAsync(T entity)
    {
        entity.Id = Guid.NewGuid();
        await _dbContext.Set<T>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }    

    public async Task UpdateAsync(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync();
    }
}
