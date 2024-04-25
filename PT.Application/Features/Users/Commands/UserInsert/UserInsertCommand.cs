using MediatR;
using PT.Application.Models.Responses;

namespace PT.Application.Features.Users.Commands.UserInsert
{
    public class UserInsertCommand : IRequest<IResponse>
    {
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string PaternalLastname { get; set; }
        public string MaternalLastname { get; set; }
    }
}
