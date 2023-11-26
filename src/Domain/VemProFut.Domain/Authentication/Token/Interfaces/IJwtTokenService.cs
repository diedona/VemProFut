using VemProFut.Domain.Entities;

namespace VemProFut.Domain.Authentication.Token.Interfaces
{
    public interface IJwtTokenService
    {
        string GenerateToken(UserEntity user);
    }
}
