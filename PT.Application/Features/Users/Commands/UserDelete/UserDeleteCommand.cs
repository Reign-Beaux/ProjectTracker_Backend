using MediatR;
using PT.Application.Services.ResponseManagement.Models;

namespace PT.Application.Features.Users.Commands.UserDelete
{
    public class UserDeleteCommand : IRequest<IResponse>
    {
        public int Id { get; set; }

        public UserDeleteCommand(int? id)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
        }
    }
}
