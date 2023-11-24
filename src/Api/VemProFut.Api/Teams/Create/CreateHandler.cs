using MediatR;

namespace VemProFut.Api.Teams.Create
{
    public class CreateHandler : IRequestHandler<CreateRequest, Unit>
    {
        public async Task<Unit> Handle(CreateRequest request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            return Unit.Value;
        }
    }
}
