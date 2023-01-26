using Microsoft.EntityFrameworkCore;
using OnlineAccountingServer.Domain;
using OnlineAccountingServer.Domain.AppEntities;
using OnlineAccountingServer.Persistance.Context;


namespace OnlineAccountingServer.Persistance
{
    public sealed class ContextService : IContextService
    {
        private readonly AppDbContext _appContext;

        public ContextService(AppDbContext appContext)
        {
            _appContext = appContext;
        }

        public DbContext CreateDbContextInstance(string companyId)
        {
            Company company = _appContext.Set<Company>().Find(companyId);
            return new CompanyDbContext(company);
        }
    }
}
