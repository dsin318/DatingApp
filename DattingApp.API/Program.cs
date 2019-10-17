using DattingApp.API.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DattingApp.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
           var host = CreateWebHostBuilder(args).Build();
           using (var scope = host.Services.CreateScope())
           {
               var services = scope.ServiceProvider;

               try
               {
                   var context =  services.GetRequiredService<DataContext>();
                   context.Database.Migrate();
                   seed.SeedUser(context);
               }
               catch (System.Exception ex)
               {
                   
                   var logger = services.GetRequiredService<ILogger<Program>>();
                   logger.LogError(ex.Message,"An Error during Migration");
               }
           }
           host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
