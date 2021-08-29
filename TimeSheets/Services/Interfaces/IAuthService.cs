using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.Services.Auth.Responses;

namespace TimeSheets.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> Authenticate(string user, string password);
    }
}
