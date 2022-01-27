using cronos.entity.Entity;
using cronos.infrastructure.Tools;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace cronos.api.Extensions
{
    public static class Token
    {
        public static string Generate(Administrator administrator)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Cryptography.Key;

            var lst = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, administrator.id.ToString()),
                    new Claim(ClaimTypes.Email, administrator.email)
                };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(lst),

                Expires = DateTime.UtcNow.AddHours(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
