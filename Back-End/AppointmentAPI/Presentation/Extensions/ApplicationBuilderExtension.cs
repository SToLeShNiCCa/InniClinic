using Infrastructure.DBSettings.DBContext;
using Microsoft.EntityFrameworkCore;
using Presentation.Share;

namespace Presentation.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder UseProgramConfiguration(
            this IApplicationBuilder app, IWebHostEnvironment environment)
        {
            return app
                .AddCorsPolitics()
                .UseSwagger(environment)
                .ProgramConfigurations()
                .UseMigrations();
        }
        private static IApplicationBuilder UseSwagger(this IApplicationBuilder app, IWebHostEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            return app;
        }

        private static IApplicationBuilder ProgramConfigurations(this IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseMiddleware<ExceptionHandlerMiddleware>();

            return app;
        }

        private static IApplicationBuilder UseMigrations(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<AppointmentDbContext>();
            db.Database.Migrate();

            return app;
        }

        private static IApplicationBuilder AddCorsPolitics(this IApplicationBuilder app)
        {
            app.UseCors("AllowAngularApp");

            return app;
        }
    }
}
