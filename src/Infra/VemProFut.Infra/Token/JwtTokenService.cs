using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using VemProFut.Domain.Token;

namespace VemProFut.Infra.Token
{
    public class JwtTokenService : IJwtTokenService
    {
        public string GenerateToken()
        {
            var handler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("batata"); // todo: get key from appsettings
            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature
            );

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = credentials,
                Expires = DateTime.UtcNow.AddMinutes(5)
            };

            var token = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(token);
        }
    }
}
