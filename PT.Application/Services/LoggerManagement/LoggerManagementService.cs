using PT.Application.Static;
using PT.Domain.ProjectTrackerTools;
using PT.Infraestructure.Persistence.ProjectTrackerTools.Logger.Models;
using PT.Infraestructure.Persistence.ProjectTrackerTools.UnitOfWork;

namespace PT.Application.Services.LoggerManagement
{
    public class LoggerManagementService
    {
        private readonly IUnitOfWorkProjectTrackerTools _tools;

        public LoggerManagementService(IUnitOfWorkProjectTrackerTools tools)
        {
            _tools = tools;
        }

        public async Task InsertLogger(Type featureClass, int code, string message)
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

        public async Task InsertLogger(string service, string method, string message)
        {
            InsertLoggerParameters parameters = new() { Feature = service, Method = method, Code = StatusResponse.INTERNAL_SERVER_ERROR, Description = message };
            var tableName = EntityToTable.Convert<Logger>();
            await _tools.LoggerRepository.Insert(tableName, parameters);
            _tools.Commit();
        }
    }
}
