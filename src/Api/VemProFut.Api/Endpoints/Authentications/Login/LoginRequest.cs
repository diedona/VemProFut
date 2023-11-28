using MediatR;

namespace VemProFut.Api.Endpoints.Authentications.Login
{
    public record LoginRequest(string Username, string Password) : IRequest<LoginResponse>;

}
