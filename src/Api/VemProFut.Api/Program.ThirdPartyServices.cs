using Carter;

namespace VemProFut.Api
{
    public static class ProgramThirdPartyServices
    {
        public static void AddThirdPartyServices(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddCarter();
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(typeof(Program).Assembly));
        }
    }
}
