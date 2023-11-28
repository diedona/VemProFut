using VemProFut.Domain.Authentication.Token.Interfaces;
using VemProFut.Infra.Token;

namespace VemProFut.Api.Configurations
{
    public static class DomainServices
    {
        public static void AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IJwtTokenService, JwtTokenService>();
        }
    }
}
