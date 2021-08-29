using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using TimeSheets.Services.Auth.Responses;
using TimeSheets.Services.Interfaces;

namespace TimeSheets.Services.Auth
{
    public sealed class AuthService : IAuthService
    {
        private IDictionary<string, string> _customers = new Dictionary<string, string>(){ {"test", "test"} };
        public const string SecretCode = "printer printer printer printer printer printer printer printer printer printer printer";

        public async Task<string> Authenticate(string user, string password)
        {
            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(password))
            {
                return string.Empty;
            }

            int i = 0;

            return await Task.Run(async () =>
            {
                foreach (var pair in _customers)
                {
                    i++;
                    if (string.CompareOrdinal(pair.Key, user) == 0 && string.CompareOrdinal(pair.Value, password) == 0)
                    {
                        return await GenerateJwtToken(i);
                    }
                }

                return string.Empty;
            });
        }

        private async Task<string> GenerateJwtToken(int id)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = await Task.Run(() => Encoding.ASCII.GetBytes(SecretCode));

            var tokenDescriptor = await Task.Run(() => new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            return await Task.Run(async () =>
            {
                var token = await Task.Run(() => tokenHandler.CreateToken(tokenDescriptor));
                return await Task.Run(() => tokenHandler.WriteToken(token));
            });
        }
    }
}
