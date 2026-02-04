using Application.Extension;
using Infrastructure.DBSettings;
using Infrastructure.Extension;
using Presentation.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));

builder.Services.AddInfrastructureLayer();
builder.Services.AddApplicationLayer();
builder.Services.AddProgramServices(builder.Configuration);

var app = builder.Build();

app.AddApplicationSettings(builder.Environment);

app.MapControllers();

app.Run();