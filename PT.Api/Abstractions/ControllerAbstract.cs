using MediatR;
using Microsoft.AspNetCore.Mvc;
using PT.Application.Models.Responses;
using PT.Application.Static;

namespace PT.Api.Abstractions
{
    public abstract class ControllerAbstract : ControllerBase
    {
        protected readonly IMediator _mediator;

        public ControllerAbstract(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected IActionResult HandleResponse(IResponse response)
        {
            Dictionary<int, Func<IResponse, IActionResult>> responseDictionary = new()
            {
                { StatusResponse.OK, Ok },
                { StatusResponse.BAD_REQUEST, BadRequest },
                { StatusResponse.NOT_FOUND, NotFound },
                { StatusResponse.INTERNAL_SERVER_ERROR, response => StatusCode(500, response.Message) },
                { StatusResponse.UNAUTHORIZED, Unauthorized }
            };

            return responseDictionary[response.Status](response);
        }
    }

}
