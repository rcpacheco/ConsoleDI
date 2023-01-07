using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ConsoleDI;

var builder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", false, false);

var configuration = builder.Build();

var serviceProvider = new ServiceCollection()
    .AddSingleton<IConfiguration>(configuration)
    .AddScoped<Application>()
    .BuildServiceProvider();

using (var scope = serviceProvider.CreateScope())
{
    var app = scope.ServiceProvider.GetRequiredService<Application>();
    app.Run(args);
}
