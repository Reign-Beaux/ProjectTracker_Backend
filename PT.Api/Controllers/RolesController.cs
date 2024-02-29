using MediatR;
using Microsoft.AspNetCore.Mvc;
using PT.Application.Features.Roles.Commands.RoleInsert;
using PT.Application.Features.Roles.Queries.RoleGetAll;
using PT.Application.Features.Roles.Queries.RoleGetById;

namespace PT.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : BaseController
    {
        public RolesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var request = new RoleGetAllQuery();
            var response = await _mediator.Send(request);
            return HandleResponse(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var request = new RoleGetByIdQuery(id);
            var response = await _mediator.Send(request);
            return HandleResponse(response);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] RoleInsertCommand request)
        {
            var response = await _mediator.Send(request);
            return HandleResponse(response);
        }
    }
}
