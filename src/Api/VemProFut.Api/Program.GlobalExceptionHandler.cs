using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using VemProFut.Domain.Error;

namespace VemProFut.Api
{
    public static class Program
    {
        public static void AddCustomExceptionHandlers(this IServiceCollection services)
        {
            services.AddExceptionHandler<GlobalExceptionHandler>();
        }
    }

    public class GlobalExceptionHandler(
        ILogger<GlobalExceptionHandler> _logger
    ) : IExceptionHandler
    {

        public ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken
        )
        {
            _logger.LogError(exception: exception, message: exception.ToString());

            if(exception is UnauthorizedAccessException)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.WriteAsJsonAsync<GlobalErrorResponse>(
                    new() { Message = "GTFO"}, 
                    cancellationToken: cancellationToken
                );

                return new ValueTask<bool>(true);
            }

            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.WriteAsJsonAsync<GlobalErrorResponse>(
                new(),
                cancellationToken: cancellationToken
            );
            return new ValueTask<bool>(true);
        }
    }
}
