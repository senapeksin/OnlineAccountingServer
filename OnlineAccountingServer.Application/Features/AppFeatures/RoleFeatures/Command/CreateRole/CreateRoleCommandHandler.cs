using OnlineAccountingServer.Application.Messaging;
using OnlineAccountingServer.Application.Services.AppService;
using OnlineAccountingServer.Domain.AppEntities.Identity;

namespace OnlineAccountingServer.Application.Features.AppFeatures.RoleFeatures.Command.CreateRole
{
    public sealed class CreateRoleCommandHandler : ICommandHandler<CreateRoleCommand, CreateRoleCommandResponse>
    {
        private readonly IRoleService _roleService;

        public CreateRoleCommandHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<CreateRoleCommandResponse> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            AppRole role = await _roleService.GetByCode(request.Code);
            if (role != null) throw new Exception("Bu rol daha önce kayıt edilmiştir."); 
            await _roleService.AddAsync(request);
            return new();
        }
    }
}
