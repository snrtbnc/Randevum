using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RandevumAPI.Helpers;
using RandevumAPI.Interface;
using RandevumAPI.Objects.DTO;

namespace RandevumAPI.Service
{
    public class TokenService : ITokenService
    {
        private readonly TokenSettings _tokenSettings;

        public TokenService(IOptions<TokenSettings> appSettings)
        {
            _tokenSettings = appSettings.Value;
        }
        public string GenerateToken(LoginDTO userLoginInfo, string[] roles, int ExpireTime)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_tokenSettings.Secret);

            Claim[] claims = new Claim[roles.Length];
            
            for (int i = 0; i < roles.Length; i++)
            {
                claims[i] = new Claim(ClaimTypes.Role, roles[i]);
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(ExpireTime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };


            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
    }
}