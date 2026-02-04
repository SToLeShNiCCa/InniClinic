using Application.DTO.Validator.ServiceCategoryValidator;
using Application.Services.Implementations;
using Application.Services.Interfaces;
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
                .AddServices()
                .AddValidators();
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services
                .AddScoped<IServiceServices, ServiceServices>()
                .AddScoped<IServiceCategoryServices, ServiceCategoryServices>();

            return services;
        }

        private static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<CreateServiceCategoryDTOValidator>();

            return services;
        }
    }
}
