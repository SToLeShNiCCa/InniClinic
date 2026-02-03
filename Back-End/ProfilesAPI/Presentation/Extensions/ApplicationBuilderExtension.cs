using Infrastructure.DbConfigurations.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Presentation.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder AddApplicationSettings(this IApplicationBuilder app, IWebHostEnvironment environment)
        {
            return app
                .AddCorsPolitics()
                .AddSwagger(environment)
                .AddAutoMigrations()
                .AddAuth();
        }

        private static IApplicationBuilder AddSwagger(this IApplicationBuilder app, IWebHostEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            return app;
        }

        private static IApplicationBuilder AddAuth(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();

            return app;
        }

        private static IApplicationBuilder AddAutoMigrations(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();

            var dbContext = serviceScope.ServiceProvider.GetRequiredService<ProfilesContext>();
            dbContext.Database.Migrate();

            return app;
        }

        private static IApplicationBuilder AddCorsPolitics(this IApplicationBuilder app)
        {
            app.UseCors("AllowAngularApp");

            return app;
        }
    }
}
