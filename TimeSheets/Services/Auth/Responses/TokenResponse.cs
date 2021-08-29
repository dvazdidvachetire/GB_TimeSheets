using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheets.Services.Auth.Responses
{
    public sealed class TokenResponse
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
