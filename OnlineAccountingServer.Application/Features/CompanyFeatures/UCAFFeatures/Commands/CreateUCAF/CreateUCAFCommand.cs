using OnlineAccountingServer.Application.Messaging;

namespace OnlineAccountingServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF
{
    public sealed record CreateUCAFCommand(string CompanyId, string Code, string Name, char Type) : ICommand<CreateUCAFCommandResponse>;

}
