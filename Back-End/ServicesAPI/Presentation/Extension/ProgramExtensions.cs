using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Presentation.Extension
{
    public static class ProgramExtensions
    {
        public static IServiceCollection AddProgramServices(this IServiceCollection service, IConfiguration configuration)
        {
            return service
                .AddCorsPolitics()
                .ProgramServices()
                .JwtHandler(configuration)
                .AddSwaggerGenWithAuth(configuration);
        }

        private static IServiceCollection ProgramServices(this IServiceCollection service)
        {
            service.AddControllers();
            service.AddOpenApi();
            service.AddSwaggerGen();
            service.AddAutoMapper(cfg => { }, Assembly.GetExecutingAssembly());

            return service;
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
}
