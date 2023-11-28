using VemProFut.Api.Configurations.Exceptions.Handlers;

namespace VemProFut.Api.Configurations.Exceptions
{
    public static class GlobalExceptions
    {
        public static void AddCustomExceptionHandlers(this IServiceCollection services)
        {
            services.AddExceptionHandler<UnauthorizedExceptionHandler>();
            services.AddExceptionHandler<GeneralExceptionHandler>();
        }
    }
}
