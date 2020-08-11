using DataGenerator;
using Microsoft.Extensions.DependencyInjection;
using RDSGConsole.Interfaces;
using RDSGConsole.Services;
using System;
using System.Threading;

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

            // Define the cancellation token.
            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;

            // Start program
            var service = serviceProvider.GetService<IMainService>();

            service.Start(token);
        }
    }
}
