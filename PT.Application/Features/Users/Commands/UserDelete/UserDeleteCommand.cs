using MediatR;
using PT.Application.Models.Responses;

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
