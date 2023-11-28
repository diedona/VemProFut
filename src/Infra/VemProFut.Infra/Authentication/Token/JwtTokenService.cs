using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VemProFut.Domain.Authentication.Services;
using VemProFut.Domain.Authentication.Token;
using VemProFut.Domain.Entities;
using VemProFut.Domain.Options;

namespace VemProFut.Infra.Authentication.Token
{
    public class JwtTokenService(
        IOptions<JwtConfiguration> _jwtConfigurationOption,
        AuthenticationCustomService _domainAuthenticationService
    ) : IJwtTokenService
    {
        private readonly JwtConfiguration _jwtConfigurationOption = _jwtConfigurationOption.Value;

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
                Expires = DateTime.UtcNow.AddMinutes(_jwtConfigurationOption.TimeToLiveInMinutes),
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
            claimsIdentity.AddClaim(new(ClaimTypes.Name, user.Username));

            var roleClaim = _domainAuthenticationService.GetUserRole(user);
            claimsIdentity.AddClaim(roleClaim);

            return claimsIdentity;
        }


    }
}
