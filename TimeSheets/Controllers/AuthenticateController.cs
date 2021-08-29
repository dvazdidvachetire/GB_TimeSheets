using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using TimeSheets.Services.Interfaces;

namespace TimeSheets.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthenticateController(IAuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromQuery] string user, string password)
        {
            var token = await _authService.Authenticate(user, password);

            if (token is null)
            {
                return await Task.Run(() => BadRequest(new { message = "Username or password is incorrect" }));
            }

            await _authService.SetTokenCookie(token.RefreshToken, Response);

            return Ok(token);
        }

        [Authorize]
        [HttpPost("refresh-token")]
        public async Task<IActionResult> Refresh()
        {
            var oldRefreshToken = Request.Cookies["refreshToken"];
            var newRefreshToken = await _authService.RefreshToken(oldRefreshToken);

            if (string.IsNullOrWhiteSpace(newRefreshToken))
            {
                return Unauthorized(new {message = "Invalid token"});
            }

            await _authService.SetTokenCookie(newRefreshToken, Response);

            return Ok(newRefreshToken);
        }
    }
}
