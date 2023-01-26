using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace OnlineAccountingServer.Presentation.Abstraction
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiController : ControllerBase
    {
        protected readonly IMediator _mediatr;

        protected ApiController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }
    }
}
