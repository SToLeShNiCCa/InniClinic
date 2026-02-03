using Infrastructure.DbConfigurations.Contexts;
using Infrastructure.DBSettings;
using Infrastructure.Repositories.Implementations;
using Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureLayer(
        this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .ConfigureRepositories()
            .ConfigureDatabase(configuration);
    }

    private static IServiceCollection ConfigureRepositories(this IServiceCollection services)
    {
        services.AddScoped<IReceptionistsRepository, ReceptionistsRepository>();
        services.AddScoped<IDoctorsRepository, DoctorsRepository>();
        services.AddScoped<IPatientsRepository, PatientsRepository>();
        
        return services;
    }

    private static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<DataBaseSettings>(configuration.GetSection(nameof(DataBaseSettings)));

        var dbSettings = services.BuildServiceProvider().GetRequiredService<IOptions<DataBaseSettings>>().Value;

        services.AddDbContext<ProfilesContext>(builder => builder
               .UseSqlServer(dbSettings.ConnectionString, op => op.MigrationsAssembly(typeof(ProfilesContext).Assembly)));

        return services;
    }
}
