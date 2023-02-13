using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineAccountingServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF;
using OnlineAccountingServer.Presentation.Abstraction;

namespace OnlineAccountingServer.Presentation.Controller
{
    public sealed class UCAFsController : ApiController
    {
        public UCAFsController(IMediator mediator) : base(mediator) { }


        [HttpPost]
        public async Task<IActionResult> CreateUCAF(CreateUCAFCommand request, CancellationToken cancellationToken)
        {
            CreateUCAFCommandResponse response = await _mediatr.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}
