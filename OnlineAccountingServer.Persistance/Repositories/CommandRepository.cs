using Microsoft.EntityFrameworkCore;
using OnlineAccountingServer.Domain.Abstractions;
using OnlineAccountingServer.Domain.Repositories;
using OnlineAccountingServer.Persistance.Context;

namespace OnlineAccountingServer.Persistance.Repositories
{
    public class CommandRepository<T> : ICommandRepository<T> where T : BaseEntity
    {
        private static readonly Func<CompanyDbContext, string, Task<T>>
            GetByIdCompiled =
                EF.CompileAsyncQuery((CompanyDbContext context, string id) =>
                 context.Set<T>().FirstOrDefault(p => p.Id == id)
            );

        private CompanyDbContext _context;
        public DbSet<T> Entity { get; set; }

        public void SetDbContextInstance(DbContext context)
        {
            _context = (CompanyDbContext)context;
            Entity = _context.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await Entity.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await Entity.AddRangeAsync(entities);
        }
        public void Remove(T entity)
        {
            Entity.Remove(entity);
        }

        public async Task RemoveById(string Id)
        {
            T entity = await GetByIdCompiled(_context, Id);  
            Entity.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            Entity.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            Entity.Update(entity);
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            Entity.UpdateRange(entities);
        }
    }
}
