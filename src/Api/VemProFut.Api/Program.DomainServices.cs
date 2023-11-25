using VemProFut.Domain.Token;
using VemProFut.Infra.Token;

namespace VemProFut.Api
{
    public static class ProgramDomainServices
    {
        public static void AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IJwtTokenService, JwtTokenService>();
        }
    }
}
