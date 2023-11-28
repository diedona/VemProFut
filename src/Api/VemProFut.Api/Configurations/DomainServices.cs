using VemProFut.Domain.Authentication.Services;
using VemProFut.Domain.Authentication.Token;
using VemProFut.Infra.Authentication.Token;

namespace VemProFut.Api.Configurations
{
    public static class DomainServices
    {
        public static void AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IJwtTokenService, JwtTokenService>();
            services.AddScoped<AuthenticationCustomService>();
        }
    }
}
