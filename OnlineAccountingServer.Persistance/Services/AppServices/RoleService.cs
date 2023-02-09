using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineAccountingServer.Application.Features.AppFeatures.RoleFeatures.Command.CreateRole;
using OnlineAccountingServer.Application.Services.AppService;
using OnlineAccountingServer.Domain.AppEntities.Identity;

namespace OnlineAccountingServer.Persistance.Services.AppServices
{
    public sealed class RoleService : IRoleService
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IMapper  _mapper;

        public RoleService(RoleManager<AppRole> roleManager, IMapper mapping)
        {
            _roleManager = roleManager;
            _mapper = mapping;
        }

        public async Task AddAsync(CreateRoleCommand request)
        {
            AppRole appRole = _mapper.Map<AppRole>(request);
            appRole.Id = Guid.NewGuid().ToString();
            await _roleManager.CreateAsync(appRole);
        }

        public async Task DeleteAsync(AppRole role)
        { 
            await _roleManager.DeleteAsync(role);
        }

        public async Task<IList<AppRole>> GetAllRolesAsync()
        {
            IList<AppRole> roles = await _roleManager.Roles.ToListAsync();
            return roles;
        }

        public async Task<AppRole> GetByCode(string Code)
        {
            AppRole appRole = await _roleManager.Roles.FirstOrDefaultAsync(p=>p.Code == Code);
            return appRole;
        }

        public async Task<AppRole> GetById(string Id)
        {
            AppRole appRole = await _roleManager.FindByIdAsync(Id);
            return appRole;
        }

        public async Task UpdateAsync(AppRole role)
        {
             await _roleManager.UpdateAsync(role);  
        }
    }
}
