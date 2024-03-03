using PT.Application.Static;

namespace PT.Application.Models.Responses
{
    public class Response : IResponse
    {
        public int Status { get; set; } = StatusResponse.OK;
        public string? Message { get; set; }

        public void NotFound()
        {
            Status = StatusResponse.NOT_FOUND;
            Message = ReplyMessages.RECORD_NOT_FOUND;
        }

        public void InteralServerError()
        {
            Status = StatusResponse.INTERNAL_SERVER_ERROR;
            Message = ReplyMessages.FAILED_OPERATION;
        }
    }
}
