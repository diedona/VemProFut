using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using VemProFut.Domain.Error;

namespace VemProFut.Api.Configurations
{
    public static class GlobalExceptions
    {
        public static void AddCustomExceptionHandlers(this IServiceCollection services)
        {
            services.AddExceptionHandler<UnauthorizedExceptionHandler>();
            services.AddExceptionHandler<GeneralExceptionHandler>();
        }
    }

    public class UnauthorizedExceptionHandler(
        ILogger<UnauthorizedExceptionHandler> _logger
    ) : IExceptionHandler
    {
        public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is UnauthorizedAccessException)
            {
                _logger.LogError(exception: exception, message: exception.ToString());

                httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.WriteAsJsonAsync<GlobalErrorResponse>(
                    new() { Message = "You are not welcome here, please vanish." },
                    cancellationToken: cancellationToken
                );

                return new ValueTask<bool>(true);
            }

            return new ValueTask<bool>(false);
        }
    }

    public class GeneralExceptionHandler(
        ILogger<GeneralExceptionHandler> _logger
    ) : IExceptionHandler
    {

        public ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken
        )
        {
            _logger.LogError(exception: exception, message: exception.ToString());

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
