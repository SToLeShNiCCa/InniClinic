using Infrastructure.Repository.Implementation;
using Infrastructure.Repository.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extension
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
        {
            return services.AddRepositories();
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IOfficeRepository, OfficeRepository>();
            return services;
        }
    }
}
