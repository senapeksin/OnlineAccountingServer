using Microsoft.EntityFrameworkCore;
using OnlineAccountingServer.Domain.Abstractions;

namespace OnlineAccountingServer.Domain.Repositories
{
    public interface ICommandRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task AddAsync(T entity, CancellationToken cancellationToken);
        Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken);
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
        Task RemoveById(string Id);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
