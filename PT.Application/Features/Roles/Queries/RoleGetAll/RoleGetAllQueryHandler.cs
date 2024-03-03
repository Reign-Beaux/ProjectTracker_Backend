using MediatR;
using PT.Application.Models.Responses;
using PT.Application.Services.Logger;
using PT.Application.Static;
using PT.Domain.ProjectTracker;
using PT.Infraestructure.Persistence.ProjectTracker.UnitOfWork;

namespace PT.Application.Features.Roles.Queries.RoleGetAll
{
    public class RoleGetAllQueryHandler : IRequestHandler<RoleGetAllQuery, IResponse>
    {
        private readonly IUnitOfWorkProjectTracker _projectTracker;
        private readonly LogManagementService _logManagement;

        public RoleGetAllQueryHandler(IUnitOfWorkProjectTracker projectTracker, LogManagementService logManagement)
        {
            _projectTracker = projectTracker;
            _logManagement = logManagement;
        }

        public async Task<IResponse> Handle(RoleGetAllQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseData<List<Role>>();

            try
            {
                var tableName = EntityToTable.Convert<Role>();
                response.Data = await _projectTracker.RolesRepository.GetAll<Role>(tableName);
                response.Message = GenericReplyMessages.QUERY_SUCCESS;
            }
            catch (Exception ex)
            {
                await _logManagement.InsertLog(typeof(RoleGetAllQueryHandler), StatusResponse.INTERNAL_SERVER_ERROR, ex.Message);
            }

            return response;
        }
    }
}
