using MediatR;
using PT.Application.Services.ResponseManagement;
using PT.Application.Services.ResponseManagement.Models;
using PT.Application.Static;
using PT.Domain.ProjectTracker;
using PT.Infraestructure.Persistence.ProjectTracker.UnitOfWork;

namespace PT.Application.Features.Roles.Queries.RoleGetById
{
    public class RoleGetByIdQueryHandler : IRequestHandler<RoleGetByIdQuery, IResponse>
    {
        private readonly IUnitOfWorkProjectTracker _projectTracker;
        private readonly ResponseManagementService _responseManagement;

        public RoleGetByIdQueryHandler(IUnitOfWorkProjectTracker projectTracker, ResponseManagementService responseManagement)
        {
            _projectTracker = projectTracker;
            _responseManagement = responseManagement;
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
                await _responseManagement.InteralServerError(response, typeof(RoleGetByIdQueryHandler), ex.Message);
            }

            return response;
        }
    }
}
