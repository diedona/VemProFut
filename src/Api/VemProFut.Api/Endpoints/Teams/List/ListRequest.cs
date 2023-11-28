using MediatR;

namespace VemProFut.Api.Endpoints.Teams.List
{
    public record ListRequest() : IRequest<IEnumerable<ListResponse>>;
}
