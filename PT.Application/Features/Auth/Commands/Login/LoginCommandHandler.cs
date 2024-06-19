using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PT.Application.Features.Roles.Commands.RoleInsert;
using PT.Application.Helpers;
using PT.Application.Models.Responses;
using PT.Application.Models.Settings;
using PT.Application.Services.Logger;
using PT.Application.Static;
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
        private readonly LogManagementService _logManagement;
        private readonly JwtSettings _jwtSettings;

        public LoginCommandHandler(
            IUnitOfWorkProjectTracker projectTracker,
            LogManagementService logManagement,
            IOptions<JwtSettings> jwtSettings)
        {
            _projectTracker = projectTracker;
            _logManagement = logManagement;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<IResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseData<LoginCommandResponse>();

            try
            {
                var user =
                    request.UsernameOrEmail.Contains('@')
                    ? await _projectTracker.UsersRepository.GetByEmail(request.UsernameOrEmail)
                    : await _projectTracker.UsersRepository.GetByUsername(request.UsernameOrEmail);

                if (user is null)
                {
                    var message =
                        request.UsernameOrEmail.Contains('@')
                        ? LoginCommandMesagges.EMAIL_NOT_FOUND
                        : LoginCommandMesagges.USER_NOT_FOUND;
                    response.NotFound(message);
                    return response;
                }
                var requestPassword = AesHelper.Decrypt(request.Password);

                if (!BCryptHelper.MatchText(requestPassword, user.Password))
                {
                    response.NotFound(LoginCommandMesagges.INCORRECT_PASSWORD);
                    return response;
                }

                response.Message = LoginCommandMesagges.LOGIN_SUCCESS;
                response.Data.Token = GenerateToken(user);
            }
            catch (Exception ex)
            {
                await _logManagement.InsertLog(typeof(RoleInsertCommandHandler), StatusResponse.INTERNAL_SERVER_ERROR, ex.Message);
            }

            return response;
        }

        private string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
                new("name", $"{user.Name} {user.PaternalLastname} {user.MaternalLastname}")
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
