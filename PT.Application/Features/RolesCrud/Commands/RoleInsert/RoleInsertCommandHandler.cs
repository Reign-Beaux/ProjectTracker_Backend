using MediatR;

namespace PT.Application.Features.RolesCrud.Commands.RoleInsert
{
    public class RoleInsertCommandHandler : IRequestHandler<RoleInsertCommand>
    {
        public Task<Unit> Handle(RoleInsertCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
