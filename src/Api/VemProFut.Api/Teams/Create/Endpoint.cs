using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace VemProFut.Api.Teams.Create
{
    public static class Endpoint
    {
        public static WebApplication MapTeamCreateEndpoint(this WebApplication app)
        {
            app.MapPost("api/teams", HandleAsync)
                .WithTags("teams")
                .WithDescription("creating a team")
                .Produces((int)HttpStatusCode.OK)
                .WithOpenApi();

            return app;
        }

        private static IResult HandleAsync([FromBody] Request request)
        {
            return Results.Ok();
        }
    }
}
