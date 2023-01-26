using OnlineAccountingServer.Application.Services.AppService;
using OnlineAccountingServer.Application.Services.CompanyService;
using OnlineAccountingServer.Domain;
using OnlineAccountingServer.Domain.Repositories.UCAFRepositories;
using OnlineAccountingServer.Domain.UOW;
using OnlineAccountingServer.Persistance;
using OnlineAccountingServer.Persistance.Repositories.UCAFRepositories;
using OnlineAccountingServer.Persistance.Services.AppServices;
using OnlineAccountingServer.Persistance.Services.CompanyServices;
using OnlineAccountingServer.Persistance.UOW;

namespace OnlineAccountingServer.WebApi.Configurations
{
    public class PersistanceDlServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            #region Context UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IContextService, ContextService>();
            #endregion 

            #region Repositories
            services.AddScoped<IUCAFQueryRepository, UCAFQueryRepository>();
            services.AddScoped<IUCAFCommandRepository, UCAFCommandRepository>();
            #endregion 

            #region Services
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IUCAFService, UCAFService>();

            #endregion
        }
    }
}
