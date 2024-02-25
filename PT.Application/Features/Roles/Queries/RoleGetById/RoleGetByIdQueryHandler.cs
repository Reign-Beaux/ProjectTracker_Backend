using MediatR;
using PT.Domain.ProjectTracker;
using PT.Infraestructure.Persistence.ProjectTracker.UnitOfWorkProjectTracker;

namespace PT.Application.Features.Roles.Queries.RoleGetById
{
    public class RoleGetByIdQueryHandler : IRequestHandler<RoleGetByIdQuery, Role>
    {
        private readonly IUnitOfWorkProjectTracker _projectTracker;

        public RoleGetByIdQueryHandler(IUnitOfWorkProjectTracker projectTracker)
        {
            _projectTracker = projectTracker;
        }

        public async Task<Role> Handle(RoleGetByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
