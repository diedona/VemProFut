using MediatR;
using VemProFut.Domain.Authentication.Token.Interfaces;
using VemProFut.Domain.Entities;

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
            return new(_tokenServive.GenerateToken(new UserEntity(request.Username, request.Password)));
        }
    }
}
