using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using VemProFut.Domain.Options;

namespace VemProFut.Api
{
    public static class ProgramCustomAuthentication
    {
        public static void AddCustomAuthentication(this IServiceCollection services, WebApplicationBuilder builder)
        {
            var jwtConfigurationOption = builder.Configuration
                .GetSection(JwtConfigurationOption.FieldName)
                .Get<JwtConfigurationOption>();

            ArgumentNullException.ThrowIfNull(jwtConfigurationOption, nameof(jwtConfigurationOption));

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
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
