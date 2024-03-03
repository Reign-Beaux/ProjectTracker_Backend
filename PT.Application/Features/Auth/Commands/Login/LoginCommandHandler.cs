using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PT.Application.Features.Auth.Commands.Login.Models;
using PT.Application.Features.Roles.Commands.RoleInsert;
using PT.Application.Services.ResponseManagement;
using PT.Application.Services.ResponseManagement.Models;
using PT.Domain.ProjectTracker;
using PT.Infraestructure.Persistence.ProjectTracker.UnitOfWork;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PT.Application.Features.Auth.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, IResponse>
    {
        private readonly IUnitOfWorkProjectTracker _projectTracker;
        private readonly ResponseManagementService _responseManagement;
        private readonly JwtSettings _jwtSettings;

        public LoginCommandHandler(IUnitOfWorkProjectTracker projectTracker, ResponseManagementService responseManagement, IOptions<JwtSettings> jwtSettings, )
        {
            _projectTracker = projectTracker;
            _responseManagement = responseManagement;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<IResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseData<LoginCommandResponse>();

            try
            {
                var user =
                    request.UsernameOrEmail!.Contains('@')
                    ? _projectTracker.UsersRepository.GetByEmail(request.UsernameOrEmail)
                    : _projectTracker.UsersRepository.GetByUsername(request.UsernameOrEmail);

                if (user is null)
                {

                }
            }
            catch (Exception ex)
            {
                await _responseManagement.InteralServerError(response, typeof(RoleInsertCommandHandler), ex.Message);
            }

            return response;
        }

        private string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64)
            };

            var expires = DateTime.UtcNow.AddDays(1);

            var token = new JwtSecurityToken(
               issuer: _jwtSettings.Issuer,
               audience: _jwtSettings.Audience,
               claims: claims,
               expires: expires,
               signingCredentials: credentials
           );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
