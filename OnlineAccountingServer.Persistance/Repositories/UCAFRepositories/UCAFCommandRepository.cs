using OnlineAccountingServer.Domain.CompanyEntities;
using OnlineAccountingServer.Domain.Repositories.UCAFRepositories;

namespace OnlineAccountingServer.Persistance.Repositories.UCAFRepositories
{
    public sealed class UCAFCommandRepository:CommandRepository<UniformChartOfAccount>,IUCAFCommandRepository
    {
    }
}
