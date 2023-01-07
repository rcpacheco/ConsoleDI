using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleDI
{
    internal static class Program
    {
        public static IConfiguration Configuration { get; private set; }

        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, false);

            Configuration = builder.Build();

            var serviceProvider = new ServiceCollection()
                .AddSingleton<IConfiguration>(Configuration)
                .AddScoped<Application>()
                .BuildServiceProvider();

            var app = serviceProvider.GetService<Application>();
            app.Run(args);
        }
    }
}
