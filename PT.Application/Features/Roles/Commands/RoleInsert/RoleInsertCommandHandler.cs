using MediatR;
using PT.Domain.ProjectTracker;
using PT.Infraestructure.Persistence.ProjectTracker.UnitOfWorkProjectTracker;

namespace PT.Application.Features.Roles.Commands.RoleInsert
{
    public class RoleInsertCommandHandler : IRequestHandler<RoleInsertCommand>
    {
        private readonly IUnitOfWorkProjectTracker _projectTracker;

        public RoleInsertCommandHandler(IUnitOfWorkProjectTracker projectTracker)
        {
            _projectTracker = projectTracker;
        }

        public async Task<Unit> Handle(RoleInsertCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _projectTracker.RolesRepository.Insert<Role, RoleInsertCommand>(request);
                _projectTracker.Commit();
            }
            catch(Exception ex)
            {
                throw new Exception("Error al insertar insertar un Rol");
            }

            return Unit.Value;
        }
    }
}
