using MediatR;
using Microsoft.AspNetCore.Mvc;
using PT.Application.Features.Roles.Commands.RoleInsert;

namespace PT.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : BaseController
    {
        public RolesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> InsertRole([FromBody] RoleInsertCommand request)
        {
            var response = await _mediator.Send(request);
            return HandleResponse(response);
        }
    }
}
