using MediatR;
using PT.Application.Services.ResponseManagement.Models;

namespace PT.Application.Features.Users.Commands.UserInsert
{
    public class UserInsertCommand : IRequest<IResponse>
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? PaternalLastname { get; set; }
        public string? MaternalLastname { get; set; }
    }
}
