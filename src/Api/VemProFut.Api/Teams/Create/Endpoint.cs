using Carter;
using Microsoft.AspNetCore.Mvc;

namespace VemProFut.Api.Teams.Create
{
    public class Endpoint : CarterModule
    {
        private async Task<IResult> HandleAsync(
            [FromBody] Request request
        )
        {
            await Task.CompletedTask;
            return Results.Ok();
        }

        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("api/teams", HandleAsync)
                .WithTags("teams")
                .WithDescription("creates a teams")
                .WithOpenApi();
        }
    }
}
