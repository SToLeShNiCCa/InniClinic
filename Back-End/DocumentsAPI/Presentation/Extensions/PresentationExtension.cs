using Infrastructure.DbSettings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Runtime.CompilerServices;

namespace Presentation.Extensions
{
    public static class PresentationExtension
    {
        public static IServiceCollection AddPresentation(
            this IServiceCollection services, IConfigurationBuilder configurationBuilder, IConfiguration configuration)
        {
            return services
                .AddJsonConf(configurationBuilder)
                .AddCorsPolitics()
                .AddDbSettings(configuration)
                .AddSwagger()
                .AddSwaggerGenWithAuth(configuration)
                .JwtHandler(configuration)
                .UseControllers();
        }

        private static IServiceCollection UseControllers(this IServiceCollection services)
        {
            services.AddControllers();

            return services;
        }

        private static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();

            return services;
        }

        private static IServiceCollection AddJsonConf(
            this IServiceCollection services, IConfigurationBuilder configurationBuilder)
        {
            configurationBuilder
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings{Environment
                    .GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true)
                .Build();

            return services;
        }

        private static IServiceCollection AddDbSettings(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<PhotosMongoDatabaseSettings>(configuration.GetSection("PhotosDatabaseSettings"));
            services.Configure<ResultsMongoDatabaseSettings>(configuration.GetSection("ResultsDatabaseSettings"));
            services.Configure<DocumentsMongoDatabaseSettings>(configuration.GetSection("DocumentsDatabaseSettings"));

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

        private static IServiceCollection AddCorsPolitics(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend", policy =>
                {
                    policy.WithOrigins("http://localhost:4200", "http://localhost:5012")
                          .AllowAnyMethod()
                          .AllowAnyHeader()
                          .AllowCredentials();
                });
            });

            return services;
        }

        private static IServiceCollection JwtHandler(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthorization();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(o =>
                {
                    o.RequireHttpsMetadata = false;
                    o.Audience = configuration["Authentication:Audience"];
                    o.MetadataAddress = configuration["Authentication:MetadataAddress"]!;
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = configuration["Authentication:ValidIssuer"]
                    };
                });

            return services;
        }
    }
}
