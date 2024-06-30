using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PT.Api.Abstractions;
using PT.Application.Features.Roles.Commands.RoleDelete;
using PT.Application.Features.Roles.Commands.RoleInsert;
using PT.Application.Features.Roles.Commands.RoleUpdate;
using PT.Application.Features.Roles.Queries.RoleGetAll;
using PT.Application.Features.Roles.Queries.RoleGetByFilters;
using PT.Application.Features.Roles.Queries.RoleGetById;

namespace PT.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RolesController : ControllerAbstract
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

        [HttpPost("GetByFilters")]
        public async Task<IActionResult> GetByFilters([FromBody] RoleGetByFiltersQuery request)
        {
            var response = await _mediator.Send(request);
            return HandleResponse(response);
        }



        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] RoleInsertCommand request)
        {
            var response = await _mediator.Send(request);
            return HandleResponse(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] RoleUpdateCommand request)
        {
            var response = await _mediator.Send(request);
            return HandleResponse(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var request = new RoleDeleteCommand(id);
            var response = await _mediator.Send(request);
            return HandleResponse(response);
        }
    }
}
