using Infrastructure.DBSettings.DatabaseSettings;
using Infrastructure.DBSettings.DBContext;
using Infrastructure.Repository.Implementation;
using Infrastructure.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Infrastructure.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
        {
            return services
                .DbConfiguration()
                .AddRepository();
        }

        private static IServiceCollection DbConfiguration(this IServiceCollection services)
        {
            var dbSettings = services.BuildServiceProvider().GetRequiredService<IOptions<DataBaseSettings>>().Value;

            services.AddDbContext<AppointmentDbContext>(p => p.UseNpgsql(dbSettings.ConnectionString));

            return services;
        }

        private static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();

            return services;
        }
    }
}
