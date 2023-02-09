using OnlineAccountingServer.Application.Features.AppFeatures.RoleFeatures.Command.CreateRole;
using OnlineAccountingServer.Application.Features.AppFeatures.RoleFeatures.Command.DeleteRole;
using OnlineAccountingServer.Domain.AppEntities.Identity;

namespace OnlineAccountingServer.Application.Services.AppService
{
    public interface IRoleService
    {
        Task AddAsync(CreateRoleCommand request);
        Task UpdateAsync(AppRole role);
        Task DeleteAsync(AppRole role);
        Task<IList<AppRole>> GetAllRolesAsync();
        Task<AppRole> GetById(string Id); 
        Task<AppRole> GetByCode(string Code); 
    }
}
