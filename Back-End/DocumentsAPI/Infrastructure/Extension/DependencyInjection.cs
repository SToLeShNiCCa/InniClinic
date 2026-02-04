using Azure.Storage.Blobs;
using Infrastructure.BLOBRepository.Implementation;
using Infrastructure.BLOBRepository.Interface;
using Infrastructure.MongoRepository.Documents.Implementation;
using Infrastructure.MongoRepository.Documents.Interface;
using Infrastructure.MongoRepository.Photos.Implementations;
using Infrastructure.MongoRepository.Photos.Interfaces;
using Infrastructure.MongoRepository.Results.Implementations;
using Infrastructure.MongoRepository.Results.Interfaces;
using Infrastructure.PDFGenerator.Interface;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extension
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddRepositories()
                .AddBlobContainer(configuration);
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IDocumentRepository, DocumentRepository>();
            services.AddScoped<IPhotoRepository, PhotoRepository>();
            services.AddScoped<IBlobRepository, BlobPhotoRepository>();
            services.AddScoped<IResultRepository, ResultRepository>();
            services.AddScoped<IPDFGenerator, PDFGenerator.Implementation.PDFGenerator>();

            return services;
        }

        private static IServiceCollection AddBlobContainer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAzureClients(clientBuilder =>
            {
                clientBuilder.AddBlobServiceClient(configuration["StorageConnection:blobServiceUri"]!).WithName("StorageConnection");
            });
            services.AddSingleton(_ => new BlobServiceClient("UseDevelopmentStorage=true"));

            return services;
        }
    }
}
