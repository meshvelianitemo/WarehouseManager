using Serilog;

namespace WarehouseManager.Api.Extensions
{
    public static class HostBuilderExtensions
    {
        public static IHostBuilder AddSerilogConfiguration(this IHostBuilder host)
        {
            host.UseSerilog((context, config) =>
            {
                config.ReadFrom.Configuration(context.Configuration);
            });

            return host;
        }
    }
}
