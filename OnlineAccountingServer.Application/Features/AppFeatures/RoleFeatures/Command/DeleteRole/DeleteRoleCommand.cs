using OnlineAccountingServer.Application.Messaging;

namespace OnlineAccountingServer.Application.Features.AppFeatures.RoleFeatures.Command.DeleteRole
{
    public sealed record DeleteRoleCommand(string Id) : ICommand<DeleteRoleCommandResponse>;

}
