using MediatR;
using PT.Application.Models.Responses;

namespace PT.Application.Features.Users.Commands.UserUpdate
{
    public class UserUpdateCommand : IRequest<IResponse>
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string PaternalLastname { get; set; }
        public string MaternalLastname { get; set; }
    }
}
