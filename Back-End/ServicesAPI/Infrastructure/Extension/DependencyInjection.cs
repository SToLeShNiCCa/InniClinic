using Infrastructure.DBConfiguration.DBSettings;
using Infrastructure.DBConfiguration.ServiceContext;
using Infrastructure.Repository.Implementations;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Infrastructure.Extension
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection service)
        {
            return service
                .ConfigureDatabase()
                .AddRepositories();
        }

        private static IServiceCollection ConfigureDatabase(this IServiceCollection service)
        {
            var dbSettings = service.BuildServiceProvider().GetRequiredService<IOptions<DataBaseSettings>>().Value;

            service.AddDbContext<ServicesContext>(options => options
                .UseSqlServer
                    (dbSettings.ConnectionString));

            return service;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection service)
        {
            service.AddScoped<IServiceRepository, ServiceRepository>();
            service.AddScoped<IServiceCategoryRepository, ServiceCategoryRepository>();

            return service;
        }
    }
}
