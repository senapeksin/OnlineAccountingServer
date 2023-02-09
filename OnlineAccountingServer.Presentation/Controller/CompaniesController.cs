using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineAccountingServer.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using OnlineAccountingServer.Application.Features.AppFeatures.CompanyFeatures.Commands.MigrateCompanyDatabase;
using OnlineAccountingServer.Presentation.Abstraction;

namespace OnlineAccountingServer.Presentation.Controller
{
    public class CompaniesController : ApiController
    {
        public CompaniesController(IMediator mediatr) : base(mediatr)
        {

        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateCompany(CreateCompanyCommand request)
        {
           CreateCompanyCommandResponse response = await _mediatr.Send(request);
           return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> MigrateCompanyDatabeses()
        {
            MigrateCompanyDatabasesCommand request = new();
            MigrateCompanyDatabasesCommandResponse response = await _mediatr.Send(request); 
            return Ok(response);
        }
    }
}
