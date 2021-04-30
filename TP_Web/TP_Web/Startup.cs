using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TP_Web;
using TP_Web.Models;


namespace TP_Web
{
    public class Startup : ReadMe
    {

        public Startup(IConfiguration p_config)
        {
            Configuration = p_config;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ContexteIdentit�>(options =>
                options.UseSqlServer(Configuration["ChainesConnexion:ConnexionIdentite"]));
            services.AddDbContext<ContexteAutoLoco>(options =>
                options.UseSqlServer(Configuration["ChainesConnexion:ConnexionLocoAuto"]));

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
            services.AddRazorPages();
            // services.AddSingleton<ID�p�t, D�p�tD�veloppement>(); //Singleton pour qu'il soit la m�me liste pour le site au complet.
            services.AddScoped<ID�p�t, D�p�tEF>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("controllers",
                "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });

            PeuplerIdentit�.Cr�erCompteAdmin(app.ApplicationServices, Configuration);
        }
    }
}
