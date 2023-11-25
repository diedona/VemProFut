using VemProFut.Domain.Options;

namespace VemProFut.Api
{
    public static class ProgramCustomOptions
    {
        public static void AddCustomOptions(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.Configure<JwtConfigurationOption>(builder.Configuration.GetSection(JwtConfigurationOption.FieldName));
        }
    }
}
