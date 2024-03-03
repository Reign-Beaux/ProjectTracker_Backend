using MediatR;
using PT.Application.Models.Responses;
using PT.Application.Services.Logger;
using PT.Application.Static;
using PT.Domain.ProjectTracker;
using PT.Infraestructure.Persistence.ProjectTracker.UnitOfWork;

namespace PT.Application.Features.Roles.Queries.RoleGetById
{
    public class RoleGetByIdQueryHandler : IRequestHandler<RoleGetByIdQuery, IResponse>
    {
        private readonly IUnitOfWorkProjectTracker _projectTracker;
        private readonly LogManagementService _logManagement;

        public RoleGetByIdQueryHandler(IUnitOfWorkProjectTracker projectTracker, LogManagementService logManagement)
        {
            _projectTracker = projectTracker;
            _logManagement = logManagement;
        }

        public async Task<IResponse> Handle(RoleGetByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseData<Role?>();

            try
            {
                var tableName = EntityToTable.Convert<Role>();
                var role = await _projectTracker.RolesRepository.GetById<Role>(tableName, request.Id);
                if (role is null)
                {
                    response.NotFound(SharedMessages.ROLE_NOT_FOUND);
                    return response;
                }

                response.Data = role;
                response.Message = GenericReplyMessages.QUERY_SUCCESS;
            }
            catch (Exception ex)
            {
                await _logManagement.InsertLog(typeof(RoleGetByIdQueryHandler), StatusResponse.INTERNAL_SERVER_ERROR, ex.Message);
            }

            return response;
        }
    }
}
