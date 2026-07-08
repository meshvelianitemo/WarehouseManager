namespace WarehouseManager.Api.Extensions
{
    public static class CORSConfiguration
    {
        public static IServiceCollection AddCorsConfiguration
            (this IServiceCollection services)
        {
            services.AddCors(options =>
             {
                 options.AddPolicy("AllowAll",
                     policy => policy
                         .WithOrigins(
                             "http://localhost:8080",
                             "http://127.0.0.1:8080",
                             "http://localhost:5500",
                             "http://localhost:3000",
                             "http://127.0.0.1:5500",
                             "http://localhost:3001",
                             "http://172.18.104.53:3000",
                             "http://192.168.0.8:3000",
                             "null"
                         )
                         .AllowAnyMethod()
                         .AllowAnyHeader()
                         .AllowCredentials());
             });

            return services;
        }
    }
}
