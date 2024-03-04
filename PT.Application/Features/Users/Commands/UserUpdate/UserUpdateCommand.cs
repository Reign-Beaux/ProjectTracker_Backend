using MediatR;
using PT.Application.Models.Responses;
using PT.Domain.ProjectTracker;

namespace PT.Application.Features.Users.Commands.UserUpdate
{
    public class UserUpdateCommand : User, IRequest<IResponse>
    {
    }
}
