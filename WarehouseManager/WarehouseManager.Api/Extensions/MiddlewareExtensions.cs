using Serilog;
using WarehouseManager.Api.Middleware;


namespace WarehouseManager.Api.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseApplicationMiddleware(
        this IApplicationBuilder app)
        {
            app.UseSerilogRequestLogging();

            app.UseHttpsRedirection();

            app.UseMiddleware<GlobalExceptionHandler>();

            app.UseAuthentication();

            app.UseAuthorization();

            return app;
        }
    }
}
