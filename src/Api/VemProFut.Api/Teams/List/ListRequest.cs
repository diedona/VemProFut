using MediatR;

namespace VemProFut.Api.Teams.List
{
    public record ListRequest() : IRequest<IEnumerable<ListResponse>>;
}
