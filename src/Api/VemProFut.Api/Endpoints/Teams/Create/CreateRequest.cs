using MediatR;

namespace VemProFut.Api.Endpoints.Teams.Create
{
    public record CreateRequest(string Name) : IRequest<Unit>;
}
