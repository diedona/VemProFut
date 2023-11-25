using MediatR;
using VemProFut.Domain.Token;

namespace VemProFut.Api.Logins.Login
{
    public class LoginHandler(
        IJwtTokenService _tokenServive
    ) : IRequestHandler<LoginRequest, LoginResponse>
    {
        public async Task<LoginResponse> Handle(
            LoginRequest request,
            CancellationToken cancellationToken
        )
        {
            return new("fuck you");
        }
    }
}
