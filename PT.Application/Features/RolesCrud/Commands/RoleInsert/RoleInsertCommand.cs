using MediatR;
using PT.Domain.ProjectTracker;

namespace PT.Application.Features.RolesCrud.Commands.RoleInsert
{
    public class RoleInsertCommand : Role, IRequest
    {
    }
}
