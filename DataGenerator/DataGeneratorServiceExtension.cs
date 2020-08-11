using DataGenerator.Interfaces;
using DataGenerator.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DataGenerator
{
    public static class DataGeneratorServiceExtension
    {
        public static IServiceCollection AddDataGeneratorServices(this IServiceCollection services)
        {
            // Thank you https://fmoralesdev.com/2019/09/20/extension-method-to-split-services-registrations-dependency-injection-net-core-part-iii/

            // Main Service
            services.AddScoped<IDataGenerator, Generator>();

            // Services
            services.AddScoped<IObjectGeneratorService, ObjectGeneratorService>();


            return services;
        }
    }
}
