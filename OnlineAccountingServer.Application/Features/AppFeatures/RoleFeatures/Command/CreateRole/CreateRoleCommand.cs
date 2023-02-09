using OnlineAccountingServer.Application.Messaging;

namespace OnlineAccountingServer.Application.Features.AppFeatures.RoleFeatures.Command.CreateRole
{
    public sealed record CreateRoleCommand(string Name, string Code) : ICommand<CreateRoleCommandResponse>;
 
}
