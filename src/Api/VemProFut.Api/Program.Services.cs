using Carter;

namespace VemProFut.Api
{
    public static class Program
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddCarter();
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(typeof(Program).Assembly));
        }
    }
}
