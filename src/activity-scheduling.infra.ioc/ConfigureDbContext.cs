using activity_scheduling.infra.data.DataContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace activity_scheduling.infra.ioc
{
    public static class ConfigureDbContext
    {
        public static void ConfigureDbContextService(this IServiceCollection services)
        {
            // DbContext configuration goes here
            // services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite("Data Source=activities.db"));

            //For test
            services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("Data Source=activities.db"));
        }
    }
}