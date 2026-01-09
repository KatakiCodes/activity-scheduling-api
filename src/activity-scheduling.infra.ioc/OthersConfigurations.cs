using activity_scheduling.application.Commands.CreateActivity;
using Microsoft.Extensions.DependencyInjection;

namespace activity_scheduling.infra.ioc
{
    public static class OthersConfigurations
    {
        public static void ConfigureSwaggerService(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
        public static void ConfigureMediatr(this IServiceCollection services)
        {
            services.AddMediatR(option=>option.RegisterServicesFromAssemblies(typeof(CreateActivityCommand).Assembly));
        }
    
    }
}