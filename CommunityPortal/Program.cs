using System;
using CommunityPortal.Models.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CommunityPortal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();

            InitialDatabase(host);
            
            host.Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void InitialDatabase(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<PortalContext>();

                    ContextInitializer.Initialize(context);

                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while creating the DB.");
                }
            }
        }
    }
}
