using MediatR;

namespace VemProFut.Api.Endpoints.Teams.List
{
    public class ListHandler : IRequestHandler<ListRequest, IEnumerable<ListResponse>>
    {
        public async Task<IEnumerable<ListResponse>> Handle(ListRequest request, CancellationToken cancellationToken)
        {
            return new List<ListResponse>()
            {
                new(Guid.NewGuid(), "Embodied Goats"),
                new(Guid.NewGuid(), "La'vrour Sevil")
            }.AsEnumerable();
        }
    }
}
