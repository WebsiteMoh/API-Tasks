using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Product.Data.Data.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Product.Services.Token
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly SymmetricSecurityKey _key;

        public TokenService(IConfiguration configuration) {
        _configuration= configuration;

            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:Key"])); 
        }
        public string GenerateToken(AppUser user)
        {
            var calims = new List<Claim>
            {
            new Claim(ClaimTypes.Email,user.Email) , //For exam[le put Email in the payload
            new Claim(ClaimTypes.GivenName,user.Name) ,
            new Claim("UserID",user.Id)

            }; //Data about user
            var Creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);  //To ensure that the signuture is correct
            var tokenDescriptior = new SecurityTokenDescriptor //What are the informations that need to be moved in the token
            { 
                Subject = new ClaimsIdentity(calims),
                Issuer = _configuration["BaseURL"],
                IssuedAt = DateTime.Now,
                Expires=DateTime.Now.AddDays(1),
                SigningCredentials=Creds
            };
            
            var tokenHandler =new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptior);
            return tokenHandler.WriteToken(token);
        }
    }
}
