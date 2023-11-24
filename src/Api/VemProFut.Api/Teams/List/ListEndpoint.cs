using Carter;
using Microsoft.AspNetCore.Http.HttpResults;

namespace VemProFut.Api.Teams.List
{
    public class ListEndpoint : CarterModule
    {
        private Ok<IEnumerable<ListResponse>> HandleSync()
        {
            return TypedResults.Ok(new List<ListResponse>()
            {
                new(Guid.NewGuid(), "Embodied Goats"),
                new(Guid.NewGuid(), "La'vrour Sevil")
            }.AsEnumerable());
        }

        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("api/teams", HandleSync)
                .WithTags("teams")
                .WithDescription("listing all the teams")
                .WithOpenApi();
        }
    }
}
