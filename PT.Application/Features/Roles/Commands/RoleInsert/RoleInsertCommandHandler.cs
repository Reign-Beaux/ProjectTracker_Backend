using MediatR;
using PT.Application.Models.Responses;
using PT.Application.Static;
using PT.Domain.ProjectTracker;
using PT.Infraestructure.Persistence.ProjectTracker.UnitOfWorkProjectTracker;

namespace PT.Application.Features.Roles.Commands.RoleInsert
{
    public class RoleInsertCommandHandler : IRequestHandler<RoleInsertCommand, IResponse>
    {
        private readonly IUnitOfWorkProjectTracker _projectTracker;

        public RoleInsertCommandHandler(IUnitOfWorkProjectTracker projectTracker)
        {
            _projectTracker = projectTracker;
        }

        public async Task<IResponse> Handle(RoleInsertCommand request, CancellationToken cancellationToken)
        {
            var response = new Response();

            try
            {
                await _projectTracker.RolesRepository.Insert<Role, RoleInsertCommand>(request);
                _projectTracker.Commit();
            }
            catch(Exception ex)
            {
                response.Status = StatusResponse.INTERNAL_SERVER_ERROR;
                response.Message = ReplyMessages.FAILED_OPERATION;
            }

            return response;
        }
    }
}
