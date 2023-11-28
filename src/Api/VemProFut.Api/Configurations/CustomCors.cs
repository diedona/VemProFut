using VemProFut.Domain.Options;

namespace VemProFut.Api.Configurations
{
    public static class CustomCors
    {
        public static void UseCustomCors(this WebApplication app, WebApplicationBuilder builder)
        {
            var jwtConfigurationOption = builder.Configuration
                .GetSection(JwtConfiguration.FieldName)
                .Get<JwtConfiguration>();

            ArgumentNullException.ThrowIfNull(jwtConfigurationOption, nameof(jwtConfigurationOption));

            app.UseCors(conf =>
                conf.AllowAnyHeader()
                    .AllowAnyMethod()
                    .WithOrigins(jwtConfigurationOption.Audience)
            );
        }
    }
}
