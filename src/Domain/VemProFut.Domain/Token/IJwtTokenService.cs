using VemProFut.Domain.Entities;

namespace VemProFut.Domain.Token
{
    public interface IJwtTokenService
    {
        string GenerateToken(UserEntity user);
    }
}
