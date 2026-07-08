using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Serilog;
using WarehouseManager.Api.Extensions;
using WarehouseManager.Api.Middleware;
using WarehouseManager.Application;
using WarehouseManager.Infrastructure;
using WarehouseManager.Infrastructure.Persistance;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.Sources.Clear();
builder.Configuration
    .AddJsonFile("appsettings.json", optional: true)
    .AddJsonFile("appsettings.Development.json")
    .AddEnvironmentVariables();

builder.Services.AddPresentation();
builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

builder.Host.UseSerilog((context, config) =>
    config.ReadFrom.Configuration(context.Configuration));

builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddCorsConfiguration();




var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAll");
app.UseSerilogRequestLogging();
app.UseHttpsRedirection();

app.UseMiddleware<GlobalExceptionHandler>();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
