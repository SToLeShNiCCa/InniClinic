using Application.Service.Implementation;
using Application.Service.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extension
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            return services.AddAppointmentServices();
        }

        private static IServiceCollection AddAppointmentServices(this IServiceCollection services)
        {
            services.AddScoped<IAppointmentService, AppointmentService>();

            return services;
        }
    }
}
