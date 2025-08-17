using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using api.Interfaces;
using api.Models;
using Microsoft.IdentityModel.Tokens;

namespace api.Services
{
    public class TokenService(IConfiguration config) : ITokenService
    {
        private readonly IConfiguration _config = config;
        private readonly SymmetricSecurityKey? _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:SigningKey"]));
        public string CreateToken(Account acc)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, acc.Email),
                new Claim(JwtRegisteredClaimNames.GivenName ,acc.UserName)
            };
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDiscriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds,
                Issuer = _config["JWT:Issuer"],
                Audience = _config["JWT:Audience"]
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDiscriptor);
            return tokenHandler.WriteToken(token);
        }
    }  
}