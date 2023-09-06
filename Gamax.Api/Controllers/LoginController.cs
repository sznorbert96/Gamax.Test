using Gamax.Application.Features.Users.Command.CreateUser;
using Gamax.Application.Models.Authenticaiton;
using Gamax.Identity.Contracts.Identity;
using Gamax.Identity.Services.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gamax.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        private readonly IUserAuthenticationService _userAuthentication;

        public LoginController(IJwtService jwtService, IUserAuthenticationService userAuthentication)
        {
            this._jwtService = jwtService;
            this._userAuthentication = userAuthentication;
        }

        [HttpPost(Name = "TryLogin")]
        public async Task<ActionResult<LoginResponse>> TryLogin([FromBody] LoginParameters loginParameters)
        {
            var authenticationResult = _userAuthentication.AuthenticateUser(loginParameters.Email, loginParameters.Password);

            if (!string.IsNullOrWhiteSpace(authenticationResult))
            {
                var token = _jwtService.GenerateToken(authenticationResult, loginParameters.Email);

                return new LoginResponse()
                {
                    Email = loginParameters.Email,
                    isSuccessful = true,
                    Token = token
                };
            }

            return new LoginResponse()
            {
                Email = loginParameters.Email,
                isSuccessful = false,
            };
        }
    }
}
