using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PT.Api.Abstractions;
using PT.Application.Features.Auth.Commands.Login;

namespace PT.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerAbstract
    {
        public AuthController(IMediator mediator) : base(mediator)
        {
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginCommand request)
        {
            var response = await _mediator.Send(request);

            if (response.Data.Token is not null)
            {
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true, // No accesible via JavaScript
                    Secure = true, // Solo enviar en conexiones HTTPS
                    Expires = DateTime.UtcNow.AddDays(6), // Expiración de la cookie
                    SameSite = SameSiteMode.None, // Política de SameSite
                    Domain = "localhost",
                };

                HttpContext.Response.Cookies.Append("jwt", response.Data.Token, cookieOptions);
            }

            return HandleResponse(response);
        }
    }
}
