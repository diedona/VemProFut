using MediatR;

namespace VemProFut.Api.Teams.Create
{
    public record CreateRequest(string Name) : IRequest<Unit>;
}
