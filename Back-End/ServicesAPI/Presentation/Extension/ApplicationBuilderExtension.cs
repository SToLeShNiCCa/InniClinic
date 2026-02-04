using Infrastructure.DBConfiguration.ServiceContext;
using Microsoft.EntityFrameworkCore;
using Presentation.Shared.Exceptions;

namespace Presentation.Extension
{
    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder UseProgramConfiguration(
            this IApplicationBuilder app, IWebHostEnvironment environment)
        {
            return app
                .AddCorsPolitics()
                .SwaggerExtension(environment)
                .ProgramConfiguration()
                .UseDatabaseMigrations();
        }

        private static IApplicationBuilder AddCorsPolitics(this IApplicationBuilder app)
        {
            app.UseCors("AllowAngularApp");

            return app;
        }

        private static IApplicationBuilder SwaggerExtension(this IApplicationBuilder app, IWebHostEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            
            return app;
        }

        private static IApplicationBuilder ProgramConfiguration(this IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseMiddleware<ExceptionHandlerMiddleware>();

            return app;
        }

        private static IApplicationBuilder UseDatabaseMigrations(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<ServicesContext>();
            db.Database.Migrate();

            return app;
        }
    }
}
