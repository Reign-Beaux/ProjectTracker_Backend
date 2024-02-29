using MediatR;
using Microsoft.AspNetCore.Mvc;
using PT.Application.Services.ResponseManagement.Models;
using PT.Application.Static;

namespace PT.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        protected readonly IMediator _mediator;

        public BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected IActionResult HandleResponse(IResponse response)
        {
            Dictionary<int, Func<IResponse, IActionResult>> responseDictionary = new()
            {
                { StatusResponse.OK, Ok },
                { StatusResponse.BAD_REQUEST, BadRequest },
                { StatusResponse.UNAUTHORIZED, Unauthorized },
                { StatusResponse.NOT_FOUND, NotFound },
                { StatusResponse.INTERNAL_SERVER_ERROR, response => StatusCode(500, response.Message) },
            };

            return responseDictionary[response.Status](response);
        }
    }
}
