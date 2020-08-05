using DataGenerator;
using Microsoft.Extensions.DependencyInjection;
using RDSGConsole.Interfaces;
using RDSGConsole.Services;
using System;

namespace RDSGConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Random Data Script Generator Console...");

            var serviceProvider = new ServiceCollection()
                .AddDataGeneratorServices()
                .AddScoped<IMainService, MainService>()
                .BuildServiceProvider();

            // Start program
            var service = serviceProvider.GetService<IMainService>();

            service.Start();
        }
    }
}
