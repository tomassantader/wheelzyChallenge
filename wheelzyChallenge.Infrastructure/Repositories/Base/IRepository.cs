using wheelzyChallenge.Domain.Entities;
using wheelzyChallenge.Domain.Common;

namespace wheelzyChallenge.Infrastructure.Repositories.Base;

public interface IGenericRepository { }

public interface IRepository<T> : IGenericRepository where T : Entity
{
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<T?> FindAsync(int id, CancellationToken cancellationToken = default);
    Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default);
    void Update(T entity);
}