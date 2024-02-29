using PT.Application.Static;

namespace PT.Application.Services.ResponseManagement.Models
{
    public class Response : IResponse
    {
        public int Status { get; set; } = StatusResponse.OK;
        public string? Message { get; set; }
    }
}
