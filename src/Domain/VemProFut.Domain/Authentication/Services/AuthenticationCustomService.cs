using System.Security.Claims;
using VemProFut.Domain.Authentication.Constants;
using VemProFut.Domain.Entities;

namespace VemProFut.Domain.Authentication.Services
{
    public class AuthenticationCustomService
    {
        public Claim GetUserRole(UserEntity user)
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
