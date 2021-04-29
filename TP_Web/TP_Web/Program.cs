using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using TP_Web;

namespace TP_Web
{
    public class Program : ReadMe
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
