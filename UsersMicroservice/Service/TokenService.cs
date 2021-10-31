using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace UsersMicroservice.Service
{
    public class TokenService : ITokenGenerator
    {
        public string GenerateJWTToken(string Name, string Role)
        {
            var claims = new[]
             {
                new Claim("name", Name),
                new Claim("role", Role)
               // new Claim("phone", phone)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this_is_my_secret_key"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "UserWebApi",
                audience: "CustomerWebApi",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            var response = new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                Name = Name
            };

            return JsonConvert.SerializeObject(response);


        }
    }
}
