using MediatR;
using PT.Application.Services.ResponseManagement.Models;
using PT.Domain.ProjectTracker;

namespace PT.Application.Features.Roles.Commands.RoleUpdate
{
    public class RoleUpdateCommand : Role, IRequest<IResponse>
    {
    }
}
