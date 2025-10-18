using Microsoft.EntityFrameworkCore;
using wheelzyChallenge.Domain.Common;

namespace wheelzyChallenge.Infrastructure.Repositories.Base;

public class Repository<T> : IRepository<T> where T : Entity
{
    protected readonly ApplicationDbContext DbContext;

    protected Repository(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<T>().ToListAsync(cancellationToken);
    }
    public virtual async Task<T?> FindAsync(int id, CancellationToken cancellationToken = default)
    {
        return await DbContext.FindAsync<T>(new object[] { id }, cancellationToken);
    }
    public virtual async Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default)
    {
        return (await DbContext.Set<T>().AddAsync(entity, cancellationToken)).Entity;
    }
    public virtual void Update(T entity)
    {
        DbContext.Set<T>().Update(entity);
    }
}