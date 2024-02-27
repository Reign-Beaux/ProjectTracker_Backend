using MediatR;
using PT.Application.Features.Roles.Commands.RoleInsert;
using PT.Application.Models.Responses;
using PT.Application.Services.LoggerService;
using PT.Application.Static;
using PT.Domain.ProjectTracker;
using PT.Infraestructure.Persistence.ProjectTracker.UnitOfWork;
using PT.Infraestructure.Persistence.ProjectTrackerTools.Logger.Models;

namespace PT.Application.Features.Roles.Queries.RoleGetById
{
    public class RoleGetByIdQueryHandler : IRequestHandler<RoleGetByIdQuery, IResponse>
    {
        private readonly IUnitOfWorkProjectTracker _projectTracker;
        private readonly LoggerService _logger;

        public RoleGetByIdQueryHandler(IUnitOfWorkProjectTracker projectTracker, LoggerService logger)
        {
            _projectTracker = projectTracker;
            _logger = logger;
        }

        public async Task<IResponse> Handle(RoleGetByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseData<Role?>();

            try
            {
                var tableName = EntityToTable.Convert<Role>();
                response.Data = await _projectTracker.RolesRepository.GetById<Role>(tableName, request.Id);
            }
            catch (Exception ex)
            {
                response.Status = StatusResponse.INTERNAL_SERVER_ERROR;
                response.Message = ReplyMessages.FAILED_OPERATION;
                var namespaceParts = typeof(RoleInsertCommandHandler).Namespace?.Split('.');
                var feature = namespaceParts?.TakeWhile(part => part != "Queries").LastOrDefault();
                await _logger.InsertLogger(new InsertLoggerParameters { Feature = feature, Method = GetType().Name, Code = StatusResponse.INTERNAL_SERVER_ERROR, Description = ex.Message });
            }

            return response;
        }
    }
}
