using Presentation.Share;

namespace Presentation.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder AddApplicationSettings(
            this IApplicationBuilder app, IWebHostEnvironment environment)
        {
            return app
                .AddCorsPolitics()
                .AddSwagger(environment)
                .AddApplicationConfigurations();
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

        private static IApplicationBuilder AddApplicationConfigurations(this IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
            app.UseMiddleware<ExceptionHandlerMiddleware>();
            app.UseAuthorization();

            return app;
        }

        private static IApplicationBuilder AddCorsPolitics(this IApplicationBuilder app)
        {
            app.UseCors("AllowAngularApp");

            return app;
        }
    }
}
