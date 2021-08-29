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

            if (string.IsNullOrWhiteSpace(token))
            {
                return await Task.Run(() => BadRequest(new { message = "Username or password is incorrect" }));
            }

            return Ok(token);
        }
    }
}
