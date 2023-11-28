using VemProFut.Domain.Options;

namespace VemProFut.Api.Configurations
{
    public static class CustomOptions
    {
        public static void AddCustomOptions(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.Configure<JwtConfigurationOption>(builder.Configuration.GetSection(JwtConfigurationOption.FieldName));
        }
    }
}
