using FluentValidation.Results;
using PT.Application.Static;

namespace PT.Application.Models.Responses
{
    public class Response : IResponse
    {
        public int Status { get; set; } = StatusResponse.OK;
        public string? Message { get; set; }
    }
}
