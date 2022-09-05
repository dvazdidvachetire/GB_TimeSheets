using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TimeSheets.DAL.Models;

namespace TimeSheets.Services.Interfaces
{
    public interface IAuthService
    {
        Task<TokenResponse> Authenticate(string login, string password);
        Task<string> RefreshToken(string token);
        Task SetTokenCookie(string token, HttpResponse response);
    }
}

