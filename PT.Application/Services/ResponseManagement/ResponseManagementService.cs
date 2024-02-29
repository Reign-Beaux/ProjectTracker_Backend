using PT.Application.Services.ResponseManagement.Models;
using PT.Application.Static;
using PT.Domain.ProjectTrackerTools;
using PT.Infraestructure.Persistence.ProjectTrackerTools.Logger.Models;
using PT.Infraestructure.Persistence.ProjectTrackerTools.UnitOfWork;

namespace PT.Application.Services.ResponseManagement
{
    public class ResponseManagementService
    {
        private readonly IUnitOfWorkProjectTrackerTools _tools;

        public ResponseManagementService(IUnitOfWorkProjectTrackerTools tools)
        {
            _tools = tools;
        }

        public async Task NotFound(IResponse response, Type feature, string message)
        {
            response.Status = StatusResponse.NOT_FOUND;
            response.Message = message;
            await InsertLogger(feature, StatusResponse.NOT_FOUND, message);
        }

        public async Task InteralServerError(IResponse response, Type feature, string message)
        {
            response.Status = StatusResponse.INTERNAL_SERVER_ERROR;
            response.Message = ReplyMessages.FAILED_OPERATION;
            await InsertLogger(feature, StatusResponse.INTERNAL_SERVER_ERROR, message);
        }

        private async Task InsertLogger(Type featureClass, int code, string message)
        {
            var method = featureClass.Name;
            var nameSpace = featureClass.Namespace;
            var separator = nameSpace!.Contains("Commands") ? "Commands" : "Queries";
            var namespaceParts = featureClass.Namespace?.Split('.');
            var featureName = namespaceParts?.TakeWhile(part => part != separator).LastOrDefault();

            InsertLoggerParameters parameters = new() { Feature = featureName, Method = method, Code = code, Description = message };
            var tableName = EntityToTable.Convert<Logger>();
            await _tools.LoggerRepository.Insert(tableName, parameters);
            _tools.Commit();
        }
    }
}
