using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JwtBearer
{
    class Token
    {
        public static object GetJwt(string name)
        {
            var now = DateTime.UtcNow;

            var symmetricKeyAsBase64 = "JWFF56j4T9nhi2ShJGCRGw==";
            var keyByteArray = Encoding.ASCII.GetBytes(symmetricKeyAsBase64);
            var signingKey = new SymmetricSecurityKey(keyByteArray);
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.NameId, name)
            };
            var jwt = new JwtSecurityToken(
                issuer: "yzlm.csoft",
                audience: "csoft.Audience",
                claims: claims,
                notBefore: now,
                expires: now.Add(TimeSpan.FromMinutes(2)),
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                expires_in = (int)TimeSpan.FromMinutes(2).TotalSeconds
            };

            return response;
        }
    }
}
