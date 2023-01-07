using Microsoft.Extensions.Configuration;
using System;

namespace ConsoleDI
{
    public class Application
    {
        private readonly IConfiguration configuration;

        public Application(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void Run(string[] args)
        {
            var message = configuration["Message"];
            Console.WriteLine(message);
            Console.WriteLine($"Arguments: {args.Length}");
        }
    }
}
