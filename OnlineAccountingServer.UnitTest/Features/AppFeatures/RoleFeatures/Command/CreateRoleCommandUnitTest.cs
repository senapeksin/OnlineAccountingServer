using Moq;
using OnlineAccountingServer.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using OnlineAccountingServer.Application.Features.AppFeatures.RoleFeatures.Command.CreateRole;
using OnlineAccountingServer.Application.Services.AppService;
using OnlineAccountingServer.Domain.AppEntities.Identity;
using Shouldly;

namespace OnlineAccountingServer.UnitTest.Features.AppFeatures.RoleFeatures.Command
{
    public sealed class CreateRoleCommandUnitTest
    {
        private readonly Mock<IRoleService> _roleService;

        public CreateRoleCommandUnitTest()
        {
            _roleService = new();
        }

        [Fact]
        public async Task AppRoleShouldBeNull()
        {
            AppRole appRole = (await _roleService.Object.GetByCode("UCAFF.Create"))!;
            appRole.ShouldBeNull();
        }
        [Fact]
        public async Task CreateAppRoleCommandResponseShouldNotBeNull()
        {
            var command = new CreateRoleCommand(Name: "Hesap Planı Kayıt Ekleme", Code: "UCAF.Create");
            var handler = new CreateRoleCommandHandler(_roleService.Object);
            CreateRoleCommandResponse response = await handler.Handle(command, default);
            response.ShouldNotBeNull();
            response.Message.ShouldNotBeEmpty();
        }
    }
}
