using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Supermarket.API.Misc;
using System;
using System.Linq;

[assembly: ApiConventionType(typeof(DefaultApiConventions))]
namespace Supermarket.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var seed = args.Any(r => r == "/seed");
            if (seed)
            {
                args = args.Except(new[] { "/seed" }).ToArray();
            }

            var host = CreateWebHostBuilder(args).Build();

            var env = host.Services.GetRequiredService<IHostingEnvironment>();
            if (seed || env.IsTest())
            {
                Console.WriteLine("Seeding");
                SeedData.EnsureSeedData(host.Services);
                if (seed)
                {
                    return;
                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
