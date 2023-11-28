using Carter;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace VemProFut.Api.Endpoints.Authentications.Login
{
    public class LoginEndpoint : CarterModule
    {
        private async Task<Ok<LoginResponse>> HandleAsync(
            [FromBody] LoginRequest request,
            [FromServices] ISender sender,
            CancellationToken cancellationToken
        )
        {
            var response = await sender.Send(request, cancellationToken);
            return TypedResults.Ok(response);
        }

        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("api/login", HandleAsync)
                .WithTags("login")
                .WithDescription("do login")
                .WithOpenApi();
        }
    }
}
