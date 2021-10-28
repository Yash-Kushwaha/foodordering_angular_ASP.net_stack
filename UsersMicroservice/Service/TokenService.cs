using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UsersMicroservice.Models;

namespace UsersMicroservice.Service
{
    public class TokenService : ITokenGenerator
    {
        public string GenerateJWTToken(User user)
        {
            var claims = new[]
            {
                new Claim("Address", user.Address),
                new Claim("Email", user.Email),
                new Claim("MobileNumber", user.MobileNumber),
                new Claim("Name", user.Name),
                new Claim("Password", user.Password),
                new Claim("Role", user.Role)
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
            };

            return JsonConvert.SerializeObject(response);

        }
    }
}
