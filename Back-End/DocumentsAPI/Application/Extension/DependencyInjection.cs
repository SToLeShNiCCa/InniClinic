using Application.BlobCQ.BlobPhotoCQ.Command;
using Application.Validator;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extension
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            return services
                .AddValidator()
                .AddMediatR();
        }
        private static IServiceCollection AddMediatR(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AzureUploadPhotoCommand).Assembly));

            return services;
        }

        private static IServiceCollection AddValidator(this IServiceCollection services) 
        {
            services.AddValidatorsFromAssemblyContaining<CreateResultDTOValidator>();

            return services;
        }
    }
}
