using MediatR;

namespace OnlineAccountingServer.Application.Features.AppFeatures.RoleFeatures.Command.DeleteRole
{
    public sealed class DeleteRoleRequest:IRequest<DeleteRoleResponse>
    {
        public string Id { get; set; }
    }
}
