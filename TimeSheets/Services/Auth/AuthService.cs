using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using TimeSheets.DAL.Interfaces;
using TimeSheets.DAL.Models;
using TimeSheets.Services.Interfaces;

namespace TimeSheets.Services.Auth
{
    public sealed class AuthService : IAuthService
    {
        private readonly IUserRepository _repository;
        private IDictionary<string, AuthResponse> _users = new Dictionary<string, AuthResponse>(){ {"test", new AuthResponse{ Password = "test"}} };
        public const string SecretCode = "printer printer printer printer printer printer printer printer printer printer printer";

        public AuthService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<TokenResponse> Authenticate(string login, string password)
        {
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                return null;
            }

            var users = await _repository.GetObjects();

            if (users.Count == 0)
            {
                await CreateUser(login, password);
            }

            var user = await Task.Run(() => users.SingleOrDefault(u => u.Login == login));

            var tokenResponse = new TokenResponse();

            int i = 0;

            return await Task.Run(async () =>
            {
                foreach (var pair in _users)
                {
                    i++;
                    if (string.CompareOrdinal(user?.Password, password) == 0)
                    {
                        tokenResponse.Token = await GenerateJwtToken(i, 15);
                        var refreshToken = await GenerateRefreshToken(i);
                        pair.Value.LatestRefreshToken = refreshToken;
                        tokenResponse.RefreshToken = refreshToken.Token;
                        return tokenResponse;
                    }
                }

                return null;
            });
        }

        private async Task CreateUser(string login, string password)
        {
            await Task.Run(async () =>
            {
                var user = new User();
                user.Login = login;
                user.Password = password;
                await _repository.CreateObjects(user);
            });
        }

        public async Task<string> RefreshToken(string token)
        {
            return await Task.Run(async () =>
            {
                int i = 0;

                await Task.Run(async () =>
                {
                    foreach (var pair in _users)
                    {
                        i++;
                        if (string.CompareOrdinal(pair.Value.LatestRefreshToken.Token, token) == 0 &&
                            pair.Value.LatestRefreshToken.IsExpired is false)
                        {
                            pair.Value.LatestRefreshToken = await GenerateRefreshToken(i);
                            return pair.Value.LatestRefreshToken.Token;
                        }
                    }

                    return string.Empty;
                });

                return string.Empty;
            });
        }

        private async Task<string> GenerateJwtToken(int id, int minutes)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = await Task.Run(() => Encoding.ASCII.GetBytes(SecretCode));

            var tokenDescriptor = await Task.Run(() => new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(minutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            return await Task.Run(async () =>
            {
                var token = await Task.Run(() => tokenHandler.CreateToken(tokenDescriptor));
                return await Task.Run(() => tokenHandler.WriteToken(token));
            });
        }

        private async Task<RefreshToken> GenerateRefreshToken(int id)
        {
            return await Task.Run(async () =>
            {
                var refreshToken = new RefreshToken();
                refreshToken.Expires = DateTime.Now.AddMinutes(360);
                refreshToken.Token = await GenerateJwtToken(id, 360);
                return refreshToken;
            });
        }

        public async Task SetTokenCookie(string token, HttpResponse response)
        {
            await Task.Run(async () =>
            {
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Expires = DateTimeOffset.UtcNow.AddDays(7)
                };

                await Task.Run(() => response.Cookies.Append("refreshToken", token, cookieOptions));
            });
        }
    }
}
