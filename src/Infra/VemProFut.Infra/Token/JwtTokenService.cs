using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VemProFut.Domain.Entities;
using VemProFut.Domain.Options;
using VemProFut.Domain.Token;

namespace VemProFut.Infra.Token
{
    public class JwtTokenService(
        IOptions<JwtConfigurationOption> jwtConfigurationOption
    ) : IJwtTokenService
    {
        private readonly JwtConfigurationOption _jwtConfigurationOption = jwtConfigurationOption.Value;

        public string GenerateToken(UserEntity user)
        {
            var handler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtConfigurationOption.PrivateKey);
            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature
            );

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = credentials,
                Expires = DateTime.UtcNow.AddMinutes(5),
                Issuer = _jwtConfigurationOption.Issuer,
                Audience = _jwtConfigurationOption.Audience,
                Subject = GetSubject(user)
            };

            var token = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(token);
        }

        private ClaimsIdentity GetSubject(UserEntity user)
        {
            var claimsIdentity = new ClaimsIdentity();

            claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, user.Username));

            return claimsIdentity;
        }
    }
}
