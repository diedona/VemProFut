using VemProFut.Domain.Entities;

namespace VemProFut.Domain.Authentication.Token
{
    public interface IJwtTokenService
    {
        string GenerateToken(UserEntity user);
    }
}
