
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace WarehouseManager.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            try
            {
                var assembly = typeof(DependencyInjection).Assembly;
                services.AddMediatR(config => config.RegisterServicesFromAssembly(assembly));
                services.AddValidatorsFromAssembly(assembly);
            }
            catch (ReflectionTypeLoadException ex)
            {
                foreach (var loaderEx in ex.LoaderExceptions)
                    Console.WriteLine(loaderEx?.Message);
                throw;
            }

            return services;
        }
    }
}
