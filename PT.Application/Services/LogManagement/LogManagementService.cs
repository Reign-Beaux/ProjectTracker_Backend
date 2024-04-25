using PT.Application.Static;
using PT.Domain.ProjectTrackerTools;
using PT.Infraestructure.Persistence.ProjectTrackerTools.LogManagement.Models;
using PT.Infraestructure.Persistence.ProjectTrackerTools.UnitOfWork;

namespace PT.Application.Services.Logger
{
    public class LogManagementService
    {
        private readonly IUnitOfWorkProjectTrackerTools _tools;

        public LogManagementService(IUnitOfWorkProjectTrackerTools tools)
        {
            _tools = tools;
        }

        /// <summary>
        /// To features
        /// </summary>
        /// <param name="featureClass"></param>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task InsertLog(Type featureClass, int code, string message)
        {
            var method = featureClass.Name;
            var nameSpace = featureClass.Namespace;
            var separator = nameSpace.Contains("Commands") ? "Commands" : "Queries";
            var namespaceParts = featureClass.Namespace?.Split('.');
            var featureName = namespaceParts?.TakeWhile(part => part != separator).LastOrDefault();

            InsertLogParameters parameters = new() { Feature = featureName, Method = method, Code = code, Description = message };
            var tableName = EntityToTable.Convert<Log>();
            await _tools.LogManagementRepository.Insert(tableName, parameters);
            _tools.Commit();
        }

        /// <summary>
        /// To services
        /// </summary>
        /// <param name="service"></param>
        /// <param name="method"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task InsertLog(string service, string method, string message)
        {
            InsertLogParameters parameters = new() { Feature = service, Method = method, Code = StatusResponse.INTERNAL_SERVER_ERROR, Description = message };
            var tableName = EntityToTable.Convert<Log>();
            await _tools.LogManagementRepository.Insert(tableName, parameters);
            _tools.Commit();
        }
    }
}
