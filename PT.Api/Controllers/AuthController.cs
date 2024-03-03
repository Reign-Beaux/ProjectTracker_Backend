using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PT.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        public AuthController(IMediator mediator) : base(mediator)
        {
        }
    }
}
