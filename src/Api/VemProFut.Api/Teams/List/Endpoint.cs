

using Carter;

namespace VemProFut.Api.Teams.List
{
    public class Endpoint : CarterModule
    {
        private async Task<IResult> HandleAsync()
        {
            await Task.CompletedTask;
            return Results.Ok(new List<Response>()
            {
                new(Guid.NewGuid(), "Embodied Goats"),
                new(Guid.NewGuid(), "La'vrour Sevil")
            });
        }

        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("api/teams", HandleAsync)
                .WithTags("teams")
                .WithDescription("listing all the teams")
                .WithOpenApi();
        }
    }
}
