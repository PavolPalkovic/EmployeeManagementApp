using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagementAPI.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EmployeeManagementAPI
{
    public class Program
    {
        // Runs the web application
        public static void Main(string[] args)
        {
            // Builds the web host
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                try
                {
                    var context = scope.ServiceProvider.GetService<EmployeeDbContext>();
                    //context.Database.EnsureDeleted();
                    // Creates DB if does not exist
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("{0}: An error occured while migrating the database.", ex);
                }
            }
            // Runs the web host
            host.Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
