using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheets.DAL.Models
{
    public class AuthResponse
    {
        public string Password { get; set; }
        public RefreshToken LatestRefreshToken { get; set; }
    }
}
