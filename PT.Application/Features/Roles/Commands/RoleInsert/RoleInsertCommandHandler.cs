using MediatR;
using PT.Application.Models.Responses;
using PT.Application.Services.Logger;
using PT.Application.Static;
using PT.Domain.ProjectTracker;
using PT.Infraestructure.Persistence.ProjectTracker.UnitOfWork;

namespace PT.Application.Features.Roles.Commands.RoleInsert
{
    public class RoleInsertCommandHandler : IRequestHandler<RoleInsertCommand, IResponse>
    {
        private readonly IUnitOfWorkProjectTracker _projectTracker;
        private readonly LogManagementService _logManagement;

        public RoleInsertCommandHandler(IUnitOfWorkProjectTracker projectTracker, LogManagementService logManagement)
        {
            _projectTracker = projectTracker;
            _logManagement = logManagement;
        }

        public async Task<IResponse> Handle(RoleInsertCommand request, CancellationToken cancellationToken)
        {
            var response = new Response();

            try
            {
                var tableName = EntityToTable.Convert<Role>();
                await _projectTracker.RolesRepository.Insert(tableName, request);
                _projectTracker.Commit();
                response.Message = GenericReplyMessages.SUCCESS_OPERATION;
            }
            catch(Exception ex)
            {
                await _logManagement.InsertLog(typeof(RoleInsertCommandHandler), StatusResponse.INTERNAL_SERVER_ERROR, ex.Message);
            }

            return response;
        }
    }
}
