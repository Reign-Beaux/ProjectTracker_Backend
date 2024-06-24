using MediatR;
using PT.Application.Models.Responses;

namespace PT.Application.Features.Auth.Commands.Login
{
    public class LoginCommand : IRequest<ResponseData<LoginCommandResponse>>
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }
    }
}
