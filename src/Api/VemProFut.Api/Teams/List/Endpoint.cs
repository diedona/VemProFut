

namespace VemProFut.Api.Teams.List
{
    public static class Endpoint
    {
        public static WebApplication MapTeamListEndpoint(this WebApplication app)
        {
            app.MapGet("api/teams", HandleAsync)
                .WithTags("teams")
                .WithDescription("listing all the teams")
                .Produces<IEnumerable<Response>>()
                .WithOpenApi();

            return app;
        }

        private static IResult HandleAsync(HttpContext context)
        {
            return Results.Ok(new List<Response>()
            {
                new(Guid.NewGuid(), "Embodied Goats"),
                new(Guid.NewGuid(), "La'vrour Sevil")
            });
        }
    }
}
