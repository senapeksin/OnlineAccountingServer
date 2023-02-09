using OnlineAccountingServer.Application.Messaging;

namespace OnlineAccountingServer.Application.Features.AppFeatures.RoleFeatures.Queries.GetAllRoles
{
    public sealed record GetAllRolesQuery() : IQuery<GetAllRolesQueryResponse>;

}
