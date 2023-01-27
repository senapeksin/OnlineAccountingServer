using MediatR;

namespace OnlineAccountingServer.Application.Features.AppFeatures.RoleFeatures.Command.CreateRole
{
    public sealed class CreateRoleRequest : IRequest<CreateRoleResponse>
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
