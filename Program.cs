using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DI_Configuration_Logging_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = RegisterServices(args);

            IConfiguration configuration = serviceProvider.GetService<IConfiguration>();

            Console.WriteLine(configuration["github:apiUrl"]);
        }

        private static ServiceProvider RegisterServices(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .Build();

            var serviceCollection = new ServiceCollection();
            
            serviceCollection.AddSingleton((IConfiguration)configuration);

            return serviceCollection.BuildServiceProvider();
        }
    }
}
