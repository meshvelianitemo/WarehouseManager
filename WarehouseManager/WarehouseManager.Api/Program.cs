using DotNetEnv;
using WarehouseManager.Api.Extensions;
using WarehouseManager.Application;
using WarehouseManager.Infrastructure;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.Sources.Clear();
builder.Configuration
    .AddJsonFile("appsettings.json", optional: true)
    .AddJsonFile("appsettings.Development.json")
    .AddEnvironmentVariables();

builder.Services.AddPresentation()
                .AddApplication()
                .AddInfrastructure(builder.Configuration)
                .AddJwtAuthentication(builder.Configuration)
                .AddCorsConfiguration();

builder.Host.AddSerilogConfiguration();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAll");
app.UseApplicationMiddleware();

app.MapControllers();

app.Run();
