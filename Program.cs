using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//tinfo200:[2021-02-27-shalim01-dykstra1] -- Using statement is for using subdirectories (DBInitializer). The second using statement is for code exceptions (dependency injections).
using ContosoUniversity.Data;
using Microsoft.Extensions.DependencyInjection;

namespace ContosoUniversity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //tinfo200:[2021-02-27-shalim01-dykstra1] -- These 3 statements are used to build and run the database application. The middle statement is for an exception
            //                                           if the database in variable host doesn't exist.
            var host = CreateHostBuilder(args).Build();

            CreateDbIfNotExists(host);

            host.Run();
        }

        //tinfo200:[2021-02-27-shalim01-dykstra1] -- This method is to determine if database exists or not, in which it will call the initializer class (if exists), or
        //                                           log an error with a print statement saying an error occured.
        private static void CreateDbIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<SchoolContext>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
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
