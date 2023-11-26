using Carter;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace VemProFut.Api.Teams.List
{
    public class ListEndpoint : CarterModule
    {
        private async Task<Ok<IEnumerable<ListResponse>>> HandleAsync(
            [FromServices] ISender sender,
            CancellationToken cancellationToken
        )
        {
            var response = await sender.Send(new ListRequest(), cancellationToken);
            return TypedResults.Ok(response);
        }

        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("api/teams", HandleAsync)
                .RequireAuthorization()
                .WithTags("teams")
                .WithDescription("listing all the teams")
                .WithOpenApi();
        }
    }
}
