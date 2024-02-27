using MediatR;
using PT.Application.Models.Responses;
using PT.Application.Services.LoggerService;
using PT.Application.Static;
using PT.Domain.ProjectTracker;
using PT.Infraestructure.Persistence.ProjectTracker.UnitOfWork;
using PT.Infraestructure.Persistence.ProjectTrackerTools.Logger.Models;

namespace PT.Application.Features.Roles.Commands.RoleInsert
{
    public class RoleInsertCommandHandler : IRequestHandler<RoleInsertCommand, IResponse>
    {
        private readonly IUnitOfWorkProjectTracker _projectTracker;
        private readonly LoggerService _logger;

        public RoleInsertCommandHandler(IUnitOfWorkProjectTracker projectTracker, LoggerService logger)
        {
            _projectTracker = projectTracker;
            _logger = logger;
        }

        public async Task<IResponse> Handle(RoleInsertCommand request, CancellationToken cancellationToken)
        {
            var response = new Response();

            try
            {
                if (true)
                    throw new Exception("Por mis huevos");
                var tableName = EntityToTable.Convert<Role>();
                await _projectTracker.RolesRepository.Insert(tableName, request);
                _projectTracker.Commit();
            }
            catch(Exception ex)
            {
                response.Status = StatusResponse.INTERNAL_SERVER_ERROR;
                response.Message = ReplyMessages.FAILED_OPERATION;
                var namespaceParts = typeof(RoleInsertCommandHandler).Namespace?.Split('.');
                var feature = namespaceParts?.TakeWhile(part => part != "Commands").LastOrDefault();
                await _logger.InsertLogger(new InsertLoggerParameters { Feature = feature, Method = GetType().Name, Code = StatusResponse.INTERNAL_SERVER_ERROR, Description = ex.Message });
            }

            return response;
        }
    }
}
