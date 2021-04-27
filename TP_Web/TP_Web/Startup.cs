using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TP01_Web.Models;

namespace TP01_Web
{
    public class Startup : ReadMe
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration p_config)
        {
            Configuration = p_config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddSingleton<ID�p�t, D�p�tD�veloppement>(); //Singleton pour qu'il soit la m�me liste pour le site au complet.
        }

        public void Configure(IApplicationBuilder app)
        {

            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}");
            });
        }
    }
}
