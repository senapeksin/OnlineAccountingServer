using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineAccountingServer.Application.Features.AppFeatures.AppUserFeatures.Login;
using OnlineAccountingServer.Presentation.Abstraction;

namespace OnlineAccountingServer.Presentation.Controller
{
    public class AuthController : ApiController
    {
        public AuthController(IMediator mediatr) : base(mediatr)
        {

        }


        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginCommand request)
        {
           LoginCommandResponse response=  await _mediatr.Send(request);
            return Ok(response);
        }
    }
}
