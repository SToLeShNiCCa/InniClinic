using Application.Services.Implementation;
using Application.Services.Interface;
using Application.Validator;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.Extension
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            return services
                .AddValidator()
                .AddServices()
                .AddMapper();
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IOfficeService, OfficeService>();

            return services;
        }
        
        private static IServiceCollection AddMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg => { }, Assembly.GetExecutingAssembly());

            return services;
        }

        private static IServiceCollection AddValidator(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<CreateOfficeDTOValidator>();

            return services;
        }
    }
}
