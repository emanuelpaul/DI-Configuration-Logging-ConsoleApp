using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace DI_Configuration_Logging_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .Build();

            Console.WriteLine(configuration["github:apiUrl"]);
        }
    }
}
