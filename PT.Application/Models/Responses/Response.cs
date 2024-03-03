using PT.Application.Static;

namespace PT.Application.Models.Responses
{
    public class Response : IResponse
    {
        public int Status { get; set; } = StatusResponse.OK;
        public string? Message { get; set; }

        public void NotFound(string? message = null)
        {
            Status = StatusResponse.NOT_FOUND;
            Message = message ?? GenericReplyMessages.RECORD_NOT_FOUND;
        }

        public void InteralServerError(string? message = null)
        {
            Status = StatusResponse.INTERNAL_SERVER_ERROR;
            Message = message ?? GenericReplyMessages.FAILED_OPERATION;
        }
    }
}
