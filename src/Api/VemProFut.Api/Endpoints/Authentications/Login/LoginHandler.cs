using MediatR;
using VemProFut.Domain.Authentication.Token;
using VemProFut.Domain.Entities;

namespace VemProFut.Api.Endpoints.Authentications.Login
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
