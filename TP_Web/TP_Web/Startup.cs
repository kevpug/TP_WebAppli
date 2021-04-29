using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TP_Web.Models;
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
            services.AddDbContext<ContexteIdentit�>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ChainesConnexion:ConnexionIdentite")));
            services.AddDbContext<ContexteLocoAuto>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ChainesConnexion:ConnexionLocoAuto")));

            services.AddIdentity<IdentityUser, IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            })
                    .AddEntityFrameworkStores<ContexteIdentit�>();

            //Page par d�fault pour l'authentification
            services.ConfigureApplicationCookie(options =>
                options.LoginPath = "/Utilisateur/Authentification");
            // Page par d�fault pour l'acc�s refus�
            services.ConfigureApplicationCookie(options =>
                options.AccessDeniedPath = "/Utilisateur/Acc�sRefus�");

            services.AddControllersWithViews();
            services.AddSingleton<ID�p�t, D�p�tD�veloppement>(); //Singleton pour qu'il soit la m�me liste pour le site au complet.
        }

        public void Configure(IApplicationBuilder app)
        {

            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("controllers",
                "controllers/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });
        }
    }
}
