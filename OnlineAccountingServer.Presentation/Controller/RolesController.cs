using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineAccountingServer.Application.Features.AppFeatures.RoleFeatures.Command.CreateRole;
using OnlineAccountingServer.Application.Features.AppFeatures.RoleFeatures.Command.DeleteRole;
using OnlineAccountingServer.Application.Features.AppFeatures.RoleFeatures.Command.UpdateRole;
using OnlineAccountingServer.Application.Features.AppFeatures.RoleFeatures.Queries.GetAllRoles;
using OnlineAccountingServer.Presentation.Abstraction;

namespace OnlineAccountingServer.Presentation.Controller
{
    public class RolesController : ApiController
    {
        public RolesController(IMediator mediatr) : base(mediatr)
        {

        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateRole(CreateRoleRequest request)
        {
            CreateRoleResponse response = await _mediatr.Send(request);
            return Ok(response);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetRoles()
        {
            GetAllRolesRequest request = new();
            GetAllRolesResponse response = await _mediatr.Send(request); 
            return Ok(response);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateRoles(UpdateRoleRequest request)
        {
            UpdateRoleResponse response = await _mediatr.Send(request);
            return Ok(response);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> DeleteRole(DeleteRoleRequest request)
        {
            DeleteRoleResponse response = await _mediatr.Send(request);
            return Ok(response);
        }
    }
}
