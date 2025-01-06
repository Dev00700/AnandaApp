using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyApp.Models.Common; // Add namespace for SessionManager
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Logger.WriteLog("Application is starting...", "INFO");
                var host = CreateHostBuilder(args).Build();

            // Configure the SessionManager with IHttpContextAccessor
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var httpContextAccessor = services.GetRequiredService<IHttpContextAccessor>();
                SessionManager.Configure(httpContextAccessor);

            }


            host.Run();
        }
             catch (Exception ex)
            {
                Logger.WriteException(ex); // Log startup exceptions
                throw; // Re-throw to ensure application stops in case of fatal errors
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
