using MediatR;
using Microsoft.AspNetCore.Mvc;
using PT.Application.Features.Users.Commands.UserDelete;
using PT.Application.Features.Users.Commands.UserInsert;
using PT.Application.Features.Users.Commands.UserUpdate;
using PT.Application.Features.Users.Queries.UserGetAll;
using PT.Application.Features.Users.Queries.UserGetById;

namespace PT.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        public UsersController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var request = new UserGetAllQuery();
            var response = await _mediator.Send(request);
            return HandleResponse(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var request = new UserGetByIdQuery(id);
            var response = await _mediator.Send(request);
            return HandleResponse(response);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] UserInsertCommand request)
        {
            var response = await _mediator.Send(request);
            return HandleResponse(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserUpdateCommand request)
        {
            var response = await _mediator.Send(request);
            return HandleResponse(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var request = new UserDeleteCommand(id);
            var response = await _mediator.Send(request);
            return HandleResponse(response);
        }
    }
}
