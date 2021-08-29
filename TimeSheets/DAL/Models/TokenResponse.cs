using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheets.DAL.Models
{
    public sealed class TokenResponse
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
