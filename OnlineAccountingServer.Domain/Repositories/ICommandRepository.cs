using Microsoft.EntityFrameworkCore;
using OnlineAccountingServer.Domain.Abstractions;

namespace OnlineAccountingServer.Domain.Repositories
{
    public interface ICommandRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
        Task RemoveById(string Id);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
