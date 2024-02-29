using MediatR;
using PT.Application.Services.ResponseManagement;
using PT.Application.Services.ResponseManagement.Models;
using PT.Application.Static;
using PT.Domain.ProjectTracker;
using PT.Infraestructure.Persistence.ProjectTracker.UnitOfWork;

namespace PT.Application.Features.Roles.Queries.RoleGetAll
{
    public class RoleGetAllQueryHandler : IRequestHandler<RoleGetAllQuery, IResponse>
    {
        private readonly IUnitOfWorkProjectTracker _projectTracker;
        private readonly ResponseManagementService _responseManagement;

        public RoleGetAllQueryHandler(IUnitOfWorkProjectTracker projectTracker, ResponseManagementService responseManagement)
        {
            _projectTracker = projectTracker;
            _responseManagement = responseManagement;
        }

        public async Task<IResponse> Handle(RoleGetAllQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseData<List<Role>>();

            try
            {
                var tableName = EntityToTable.Convert<Role>();
                response.Data = await _projectTracker.RolesRepository.GetAll<Role>(tableName);
            }
            catch (Exception ex)
            {
                await _responseManagement.InteralServerError(response, typeof(RoleGetAllQueryHandler), ex.Message);
            }

            return response;
        }
    }
}
