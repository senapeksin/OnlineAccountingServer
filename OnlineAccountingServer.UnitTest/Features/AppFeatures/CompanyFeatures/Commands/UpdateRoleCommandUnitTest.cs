using Moq;
using OnlineAccountingServer.Application.Features.AppFeatures.RoleFeatures.Command.CreateRole;
using OnlineAccountingServer.Application.Features.AppFeatures.RoleFeatures.Command.UpdateRole;
using OnlineAccountingServer.Application.Services.AppService;
using OnlineAccountingServer.Domain.AppEntities.Identity;
using Shouldly;

namespace OnlineAccountingServer.UnitTest.Features.AppFeatures.CompanyFeatures.Commands
{
    public sealed class UpdateRoleCommandUnitTest
    {
        private readonly Mock<IRoleService> _roleService;

        public UpdateRoleCommandUnitTest()
        {
            _roleService = new();
        }

        [Fact]
        public async Task AppRoleShoulNotBeNull()
        {
            var result = _roleService.Setup(x => x.GetById(It.IsAny<string>())).ReturnsAsync(new AppRole());
        }

        [Fact]
        public async Task AppRoleCodeShoulBeUnique()
        {
            AppRole checkRoleCode = await _roleService.Object.GetByCode("UCAFF.Create");
            checkRoleCode.ShouldBeNull();
        }

        [Fact]
        public async Task UpdateAppRoleCommandResponseShouldNotBeNull()
        {
            var command = new UpdateRoleCommand(Id: "2f4f7f93-a66d-4dbe-8cc7-f694279e0b96", Code: "Hesap Planı Kayıt Ekleme", Name: "UCAF-Create");
            var result = _roleService.Setup(x => x.GetById(It.IsAny<string>())).ReturnsAsync(new AppRole());
            var handler = new UpdateRoleCommandHandler(_roleService.Object);
            UpdateRoleCommandResponse response = await handler.Handle(command, default);
            response.ShouldNotBeNull();
            response.Message.ShouldNotBeEmpty();
        }
    }
}
