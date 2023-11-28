using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using VemProFut.Domain.Options;

namespace VemProFut.Api.Configurations
{
    public static class CustomAuthentication
    {
        public static void AddCustomAuthentication(this IServiceCollection services, WebApplicationBuilder builder)
        {
            var jwtConfigurationOption = builder.Configuration
                .GetSection(JwtConfiguration.FieldName)
                .Get<JwtConfiguration>();

            ArgumentNullException.ThrowIfNull(jwtConfigurationOption, nameof(jwtConfigurationOption));

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = jwtConfigurationOption.Issuer,
                        ValidateAudience = true,
                        ValidAudience = jwtConfigurationOption.Audience,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ClockSkew = TimeSpan.Zero,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(jwtConfigurationOption.PrivateKey)
                        )
                    };
                });
        }
    }
}
