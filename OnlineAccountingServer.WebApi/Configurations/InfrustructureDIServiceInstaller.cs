using OnlineAccountingServer.Application.Abstractions;
using OnlineAccountingServer.Infrastructure.Authentication;

namespace OnlineAccountingServer.WebApi.Configurations
{
    public class InfrustructureDIServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IJwtProvider, JwtProvider>();
        }
    }
}
