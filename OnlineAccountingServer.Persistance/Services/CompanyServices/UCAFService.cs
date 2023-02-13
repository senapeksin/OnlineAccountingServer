using AutoMapper;
using OnlineAccountingServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF;
using OnlineAccountingServer.Application.Services.CompanyService;
using OnlineAccountingServer.Domain;
using OnlineAccountingServer.Domain.CompanyEntities;
using OnlineAccountingServer.Domain.Repositories.UCAFRepositories;
using OnlineAccountingServer.Domain.UOW;
using OnlineAccountingServer.Persistance.Context;

namespace OnlineAccountingServer.Persistance.Services.CompanyServices
{
    public sealed class UCAFService : IUCAFService
    {
        private readonly IUCAFCommandRepository _commandRepository;
        private readonly IContextService _contextService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private CompanyDbContext _context;

        public UCAFService(IUCAFCommandRepository repository, IContextService contextService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _commandRepository = repository;
            _contextService = contextService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateUcafAsync(CreateUCAFCommand request, CancellationToken cancellationToken)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
            _commandRepository.SetDbContextInstance(_context);
            _unitOfWork.SetDbContextInstance(_context);

            UniformChartOfAccount uniformChartOfAccount = _mapper.Map<UniformChartOfAccount>(request);
            uniformChartOfAccount.Id = Guid.NewGuid().ToString();

            await _commandRepository.AddAsync(uniformChartOfAccount, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
