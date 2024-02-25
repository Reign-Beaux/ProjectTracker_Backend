using MediatR;
using Microsoft.AspNetCore.Mvc;
using PT.Application.Features.Roles.Commands.RoleInsert;

namespace PT.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> InsertRole([FromBody] RoleInsertCommand request)
        {
            return await _mediator.Send(request);
        }
    }
}
