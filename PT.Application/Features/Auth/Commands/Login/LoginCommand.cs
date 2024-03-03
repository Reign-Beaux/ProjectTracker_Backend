using MediatR;
using PT.Application.Services.ResponseManagement.Models;

namespace PT.Application.Features.Auth.Commands.Login
{
    public class LoginCommand : IRequest<IResponse>
    {
        public string? UsernameOrEmail { get; set; }
        public string? Password { get; set; }
    }
}
