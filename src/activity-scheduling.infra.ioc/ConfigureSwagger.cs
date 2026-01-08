using Microsoft.Extensions.DependencyInjection;

namespace activity_scheduling.infra.ioc
{
    public static class ConfigureSwagger
    {
        public static void ConfigureSwaggerService(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
    }
}