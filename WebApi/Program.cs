using DataAccess;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DataSeed;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            #region DataSeeding
            //2. Find the service layer within our scope.
            using var scope = host.Services.CreateScope();
            //3. Get the instance of AppDbContext in our services layer
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<AppDbContext>();
            //4. Call the DataGenerator to create sample data
            DataGenerator.Initialize(services); 
            #endregion

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
