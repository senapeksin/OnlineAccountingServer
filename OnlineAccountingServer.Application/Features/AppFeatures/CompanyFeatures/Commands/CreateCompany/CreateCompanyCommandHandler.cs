using OnlineAccountingServer.Application.Messaging;
using OnlineAccountingServer.Application.Services.AppService;
using OnlineAccountingServer.Domain.AppEntities;

namespace OnlineAccountingServer.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany
{
    public sealed class CreateCompanyCommandHandler : ICommandHandler<CreateCompanyCommand, CreateCompanyCommandResponse>
    {
        private readonly ICompanyService _companyService;

        public CreateCompanyCommandHandler(ICompanyService companyService)
        {
            _companyService = companyService;
        }
        public async Task<CreateCompanyCommandResponse> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            Company company = await _companyService.GetCompanyByName(request.Name);
            if (company != null) throw new Exception("Bu şirket adı daha önce kullanılmıştır.");
            await _companyService.CreateCompany(request);
            return new();
        }
    }
}
