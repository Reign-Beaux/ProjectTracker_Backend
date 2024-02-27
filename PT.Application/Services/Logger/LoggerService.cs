using PT.Application.Static;
using PT.Domain.ProjectTrackerTools;
using PT.Infraestructure.Persistence.ProjectTrackerTools.Logger.Models;
using PT.Infraestructure.Persistence.ProjectTrackerTools.UnitOfWork;

namespace PT.Application.Services.LoggerService
{
    public class LoggerService
    {
        private readonly IUnitOfWorkProjectTrackerTools _tools;

        public LoggerService(IUnitOfWorkProjectTrackerTools tools)
        {
            _tools = tools;
        }

        public async Task InsertLogger(InsertLoggerParameters parameters)
        {
            var tableName = EntityToTable.Convert<Logger>();
            await _tools.LoggerRepository.Insert(tableName, parameters);
            _tools.Commit();
        }
    }
}
