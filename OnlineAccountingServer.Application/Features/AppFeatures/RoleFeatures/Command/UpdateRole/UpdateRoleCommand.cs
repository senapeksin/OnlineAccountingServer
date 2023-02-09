using OnlineAccountingServer.Application.Messaging;

namespace OnlineAccountingServer.Application.Features.AppFeatures.RoleFeatures.Command.UpdateRole
{
    public sealed record UpdateRoleCommand(string Id, string Code, string Name) : ICommand<UpdateRoleCommandResponse>;

}
