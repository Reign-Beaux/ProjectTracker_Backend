using MediatR;
using Microsoft.AspNetCore.Mvc;
using PT.Application.Features.Auth.Commands.Login;

namespace PT.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        public AuthController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginCommand request)
        {
            var response = await _mediator.Send(request);
            return HandleResponse(response);
        }
    }
}
