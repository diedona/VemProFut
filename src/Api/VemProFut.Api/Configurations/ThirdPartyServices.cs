using Carter;

namespace VemProFut.Api.Configurations
{
    public static class ThirdPartyServices
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
