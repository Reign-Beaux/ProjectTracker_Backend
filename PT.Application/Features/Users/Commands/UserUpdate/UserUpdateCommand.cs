using MediatR;
using PT.Application.Services.ResponseManagement.Models;
using PT.Domain.ProjectTracker;

namespace PT.Application.Features.Users.Commands.UserUpdate
{
    public class UserUpdateCommand : User, IRequest<IResponse>
    {
    }
}
