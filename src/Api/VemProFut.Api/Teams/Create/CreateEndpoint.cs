using Carter;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace VemProFut.Api.Teams.Create
{
    public class CreateEndpoint : CarterModule
    {
        private async Task<Ok> HandleAsync(
            [FromBody] CreateRequest request
        )
        {
            await Task.CompletedTask;
            return TypedResults.Ok();
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
