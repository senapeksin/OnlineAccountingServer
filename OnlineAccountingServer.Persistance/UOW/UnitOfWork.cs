using Microsoft.EntityFrameworkCore;
using OnlineAccountingServer.Domain.UOW;
using OnlineAccountingServer.Persistance.Context;

namespace OnlineAccountingServer.Persistance.UOW
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private CompanyDbContext _context;
        public void SetDbContextInstance(DbContext context)
        {
            _context = (CompanyDbContext)context;
        }

        public async Task<int> SaveChangesAsync()
        {
            int count = await _context.SaveChangesAsync();
            return count;
        }
    }
}
