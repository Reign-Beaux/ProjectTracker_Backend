using PT.Application.Services.LoggerManagement;
using PT.Application.Services.ResponseManagement.Models;
using PT.Application.Static;

namespace PT.Application.Services.ResponseManagement
{
    public class ResponseManagementService
    {
        private readonly LoggerManagementService _logger;

        public ResponseManagementService(LoggerManagementService logger)
        {
            _logger = logger;
        }

        public async Task NotFound(IResponse response, Type feature, string message)
        {
            response.Status = StatusResponse.NOT_FOUND;
            response.Message = message;
            await _logger.InsertLogger(feature, StatusResponse.NOT_FOUND, message);
        }

        public async Task InteralServerError(IResponse response, Type feature, string message)
        {
            response.Status = StatusResponse.INTERNAL_SERVER_ERROR;
            response.Message = ReplyMessages.FAILED_OPERATION;
            await _logger.InsertLogger(feature, StatusResponse.INTERNAL_SERVER_ERROR, message);
        }
    }
}
