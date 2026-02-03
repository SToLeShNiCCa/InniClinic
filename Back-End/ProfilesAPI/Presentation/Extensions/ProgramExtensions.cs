using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Presentation.Extensions;

public static class ProgramExtensions
{
    public static IServiceCollection AddPresentation(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddCorsPolitics()
            .AddSwaggerGenWithAuth(configuration)
            .AddAuth(configuration)
            .AddController()
            .AddMapper();
    }

    private static IServiceCollection AddController(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSwaggerGen();

        return services;
    }

    private static IServiceCollection AddMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg => { }, Assembly.GetExecutingAssembly());

        return services;
    }

    private static IServiceCollection AddSwaggerGenWithAuth(this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddSwaggerGen(o =>
        {
            o.CustomSchemaIds(id => id.FullName!.Replace('+', '-'));

            o.AddSecurityDefinition("KeyCloak", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.OAuth2,
                Flows = new OpenApiOAuthFlows
                {
                    Implicit = new OpenApiOAuthFlow
                    {
                        AuthorizationUrl = new Uri(configuration["KeyCloak:AuthorizationUrl"]!),
                        Scopes = new Dictionary<string, string>
                 {
                     { "openid", "openid"},
                     { "profile", "profile"}
                 }
                    }
                }
            });
            var securityRequirement = new OpenApiSecurityRequirement
     {
         {
             new OpenApiSecurityScheme
             {
                 Reference = new OpenApiReference
                 {
                     Type = ReferenceType.SecurityScheme,
                     Id = "KeyCloak"
                 },
                 In = ParameterLocation.Header,
                 Name = "Bearer",
                 Scheme = "Bearer"
             },[]
         }
     };
            o.AddSecurityRequirement(securityRequirement);
        });

        return services;
    }

    private static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
    {


        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = false;
                o.Audience = configuration["Authentication:Audience"];
                o.MetadataAddress = configuration["Authentication:MetadataAddress"]!;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = configuration["Authentication:ValidIssuer"],
                    ValidateAudience = true,
                    ValidAudience = configuration["Authentication:Audience"],
                    ValidateLifetime = true
                };
            });
        services.AddAuthorization();

        return services;
    }

    private static IServiceCollection AddCorsPolitics(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAngularApp", policy =>
            {
                policy.WithOrigins("http://localhost:4200")
                      .AllowAnyHeader()
                      .AllowAnyMethod()
                      .AllowCredentials();
            });
        });

        return services;
    }
}
