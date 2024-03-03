using MediatR;
using PT.Application.Models.Responses;
using PT.Domain.ProjectTracker;

namespace PT.Application.Features.Roles.Commands.RoleUpdate
{
    public class RoleUpdateCommand : Role, IRequest<IResponse>
    {
    }
}
