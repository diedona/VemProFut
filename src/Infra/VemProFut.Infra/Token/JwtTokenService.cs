using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VemProFut.Domain.Authentication.Constants;
using VemProFut.Domain.Authentication.Token.Interfaces;
using VemProFut.Domain.Entities;
using VemProFut.Domain.Options;

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

            var role = GetUserRole(user);
            claimsIdentity.AddClaim(role);

            return claimsIdentity;
        }

        private Claim GetUserRole(UserEntity user)
        {
            return user.Username switch
            {
                "diegodona" => new(ClaimTypes.Role, UserRolesConsts.AdminRole),
                "john" or "daphne" => new(ClaimTypes.Role, UserRolesConsts.ReaderRole),
                "linda" or "maria" => new(ClaimTypes.Role, UserRolesConsts.WriterRole),
                _ => throw new UnauthorizedAccessException(nameof(user.Username))
            };
        }
    }
}
