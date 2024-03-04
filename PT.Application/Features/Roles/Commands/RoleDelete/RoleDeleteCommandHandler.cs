using MediatR;
using PT.Application.Models.Responses;
using PT.Application.Services.Logger;
using PT.Application.Static;
using PT.Domain.ProjectTracker;
using PT.Infraestructure.Persistence.ProjectTracker.UnitOfWork;

namespace PT.Application.Features.Roles.Commands.RoleDelete
{
    public class RoleDeleteCommandHandler : IRequestHandler<RoleDeleteCommand, IResponse>
    {
        private readonly IUnitOfWorkProjectTracker _projectTracker;
        private readonly LogManagementService _logManagement;

        public RoleDeleteCommandHandler(IUnitOfWorkProjectTracker projectTracker, LogManagementService logManagement)
        {
            _projectTracker = projectTracker;
            _logManagement = logManagement;
        }

        public async Task<IResponse> Handle(RoleDeleteCommand request, CancellationToken cancellationToken)
        {
            var response = new Response();

            try
            {
                var tableName = EntityToTable.Convert<Role>();
                var role = await _projectTracker.RolesRepository.GetById<Role>(tableName, request.Id);
                if (role is null)
                {
                    response.NotFound(RolesMessages.ROLE_NOT_FOUND);
                    return response;
                }

                await _projectTracker.RolesRepository.Delete<Role>(tableName, request.Id);
                _projectTracker.Commit();
                response.Message = GenericReplyMessages.SUCCESS_OPERATION;
            }
            catch (Exception ex)
            {
                await _logManagement.InsertLog(typeof(RoleDeleteCommandHandler), StatusResponse.INTERNAL_SERVER_ERROR, ex.Message);
            }

            return response;
        }
    }
}
