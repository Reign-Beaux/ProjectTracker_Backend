using MediatR;
using PT.Application.Services.ResponseManagement;
using PT.Application.Services.ResponseManagement.Models;
using PT.Application.Static;
using PT.Domain.ProjectTracker;
using PT.Infraestructure.Persistence.ProjectTracker.UnitOfWork;

namespace PT.Application.Features.Roles.Commands.RoleUpdate
{
    public class RoleUpdateCommandHandler : IRequestHandler<RoleUpdateCommand, IResponse>
    {
        private readonly IUnitOfWorkProjectTracker _projectTracker;
        private readonly ResponseManagementService _responseManagement;

        public RoleUpdateCommandHandler(IUnitOfWorkProjectTracker projectTracker, ResponseManagementService responseManagement)
        {
            _projectTracker = projectTracker;
            _responseManagement = responseManagement;
        }

        public async Task<IResponse> Handle(RoleUpdateCommand request, CancellationToken cancellationToken)
        {
            var response = new Response();

            try
            {
                var tableName = EntityToTable.Convert<Role>();
                var currentRole = await _projectTracker.RolesRepository.GetById<Role>(tableName, request.Id);

                if (currentRole is null)
                {
                    await _responseManagement.NotFound(response, typeof(RoleUpdateCommandHandler), "Role no encontrado");
                    return response;
                }

                await _projectTracker.RolesRepository.Update(tableName, request);
                _projectTracker.Commit();
            }
            catch (Exception ex)
            {
                await _responseManagement.InteralServerError(response, typeof(RoleUpdateCommandHandler), ex.Message);
            }

            return response;
        }
    }
}
