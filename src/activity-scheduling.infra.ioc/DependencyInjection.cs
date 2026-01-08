using Microsoft.Extensions.DependencyInjection;

namespace activity_scheduling.infra.ioc
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.ConfigureDbContextService();
            services.ConfigureRepositoryServices();
            services.ConfigureSwaggerService();
        }
    }
}