using Serilog;


namespace WarehouseManager.Api.Extensions
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder UseApplicationMiddleware(
            this IApplicationBuilder app)
        {
            app.UseSerilogRequestLogging();


        }
    }
}
