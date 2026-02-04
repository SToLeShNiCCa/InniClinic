namespace Presentation.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder UseApplicationSettings(this IApplicationBuilder app, IHostEnvironment environment)
        {
            return app
                .AddCorsPolitics()
                .AddSwaggerUI(environment)
                .UseRoutingSettings();
        }

        private static IApplicationBuilder AddSwaggerUI(this IApplicationBuilder app, IHostEnvironment environment)
        {

            if (environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            return app;
        }

        private static IApplicationBuilder UseRoutingSettings(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();

            return app;
        }

        private static IApplicationBuilder AddCorsPolitics(this IApplicationBuilder app)
        {
            app.UseCors("AllowFrontend");

            return app;
        }
    }
}
