using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SSO.Domain.Auth
{
    public class AuthenticateService
    {
        public string CreateToken()
        {
            var username = "42";
            var expireTokenInMinutes = 60;

            var claimsIdentity = new List<Claim>();
            claimsIdentity.Add(new Claim(ClaimTypes.Name, username));

            var symmetricKey = Convert.FromBase64String("aXQgaXMgYSBzdHJpbmcgd2l0aCAxNiBjaGFycw==");
            var tokenHandler = new JwtSecurityTokenHandler();

            var now = DateTime.Now;

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claimsIdentity),
                //NotBefore = now,
                Expires = now.AddDays(expireTokenInMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var stoken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(stoken);

            return token;
        }
    }
}
