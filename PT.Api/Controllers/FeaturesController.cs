using MediatR;
using Microsoft.AspNetCore.Mvc;
using PT.Api.Abstractions;
using PT.Application.Features.Features.Commands.FeatureDelete;
using PT.Application.Features.Features.Commands.FeatureInsert;
using PT.Application.Features.Features.Commands.FeatureUpdate;
using PT.Application.Features.Features.Queries.FeatureGetAll;
using PT.Application.Features.Features.Queries.FeatureGetById;

namespace PT.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerAbstract
    {
        public FeaturesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var request = new FeatureGetAllQuery();
            var response = await _mediator.Send(request);
            return HandleResponse(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var request = new FeatureGetByIdQuery(id);
            var response = await _mediator.Send(request);
            return HandleResponse(response);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] FeatureInsertCommand request)
        {
            var response = await _mediator.Send(request);
            return HandleResponse(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] FeatureUpdateCommand request)
        {
            var response = await _mediator.Send(request);
            return HandleResponse(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var request = new FeatureDeleteCommand(id);
            var response = await _mediator.Send(request);
            return HandleResponse(response);
        }
    }
}
