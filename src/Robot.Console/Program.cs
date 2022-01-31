using Microsoft.Extensions.DependencyInjection;
using Robot.Interfaces;
using Robot.Services;
using System;

namespace Robot.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = ResolveServices();

            var robotService = serviceProvider.GetService<IRobotService>();

            ConsoleApp.Run(robotService);

            DisposeService(serviceProvider);
            
        }

        private static IServiceProvider ResolveServices()
        {
            var collection = new ServiceCollection();

            collection.AddScoped<IRobotService, RobotService>();

            IServiceProvider serviceProvider = collection.BuildServiceProvider();
            
            return serviceProvider;
        }

        private static void DisposeService(IServiceProvider serviceProvider)
        {
            if (serviceProvider is IDisposable)
            {
                ((IDisposable)serviceProvider).Dispose();
            }
        }
    }
}
