using activity_scheduling.domain.Repositories.Contracts;
using activity_scheduling.infra.data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace activity_scheduling.infra.ioc
{
    public static class ConfigureRepositories
    {
        public static void ConfigureRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<IActivityRepository, ActivityRepository>(); 
        }
    }
}