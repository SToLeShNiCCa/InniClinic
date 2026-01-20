using Application.Extension;
using Infrastructure.DBSettings.DatabaseSettings;
using Infrastructure.Extension;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Presentation.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json")
    .AddJsonFile($"appsettings{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true)
    .Build();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(o =>
    {
        o.RequireHttpsMetadata = false;
        o.Audience = builder.Configuration["Authentication:Audience"];
        o.MetadataAddress = builder.Configuration["Authentication:MetadataAddress"]!;
        o.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = builder.Configuration["Authentication:ValidIssuer"]
        };
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

builder.Services.Configure<DataBaseSettings>(builder.Configuration.GetSection(nameof(DataBaseSettings)));

builder.Services.AddInfrastructureLayer();
builder.Services.AddApplicationLayer();
builder.Services.AddProgramServices(builder.Configuration);

var app = builder.Build();

app.UseCors("AllowAngularApp");

app.UseProgramConfiguration(app.Environment);

app.MapControllers();

app.Run();