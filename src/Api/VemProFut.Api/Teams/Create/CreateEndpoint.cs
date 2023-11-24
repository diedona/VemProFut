﻿using Carter;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace VemProFut.Api.Teams.Create
{
    public class CreateEndpoint : CarterModule
    {
        private async Task<Ok> HandleAsync(
            [FromBody] CreateRequest request,
            [FromServices] ISender sender,
            CancellationToken cancellationToken
        )
        {
            await sender.Send(request, cancellationToken);
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
