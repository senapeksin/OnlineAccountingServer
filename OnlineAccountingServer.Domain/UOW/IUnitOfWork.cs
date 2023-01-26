using Microsoft.EntityFrameworkCore;

namespace OnlineAccountingServer.Domain.UOW
{
    public interface IUnitOfWork
    {
        void SetDbContextInstance(DbContext context);
        Task<int> SaveChangesAsync();
    }
}
