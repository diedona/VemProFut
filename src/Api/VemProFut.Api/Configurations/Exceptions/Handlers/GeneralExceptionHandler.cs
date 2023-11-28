using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using VemProFut.Domain.Error;

namespace VemProFut.Api.Configurations.Exceptions.Handlers
{
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
