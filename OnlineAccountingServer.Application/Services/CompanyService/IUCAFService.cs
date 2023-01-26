using OnlineAccountingServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF;

namespace OnlineAccountingServer.Application.Services.CompanyService
{
    public interface IUCAFService
    {
        Task CreateUcafAsync(CreateUCAFRequest request);
    }
}
