using AutoMapper;
using OnlineAccountingServer.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using OnlineAccountingServer.Application.Features.AppFeatures.RoleFeatures.Command.CreateRole;
using OnlineAccountingServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF;
using OnlineAccountingServer.Domain.AppEntities;
using OnlineAccountingServer.Domain.AppEntities.Identity;
using OnlineAccountingServer.Domain.CompanyEntities;

namespace OnlineAccountingServer.Persistance.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCompanyCommand, Company>();
            CreateMap<CreateUCAFCommand, UniformChartOfAccount>();
            CreateMap<CreateRoleCommand, AppRole>();
        }
    }
}
