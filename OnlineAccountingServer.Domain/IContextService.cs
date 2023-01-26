using Microsoft.EntityFrameworkCore;

namespace OnlineAccountingServer.Domain
{
    public interface IContextService // tek görevi :benim verdiğim isteğe göre database instance üretmek
    {
        DbContext CreateDbContextInstance(string companyId);
    }
}
