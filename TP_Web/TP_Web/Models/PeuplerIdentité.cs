using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP_Web.Models
{
    public class PeuplerIdentité
    {

        public static void CréerCompteAdmin(IServiceProvider p_serviceProvider,
                                            IConfiguration p_configuration)
        {
            CréerCompteAdminAsync(p_serviceProvider, p_configuration).Wait();
        }
        public static async Task CréerCompteAdminAsync(IServiceProvider p_serviceProvider,
                                                       IConfiguration p_configuration)
        {
            p_serviceProvider = p_serviceProvider.CreateScope().ServiceProvider;
            UserManager<IdentityUser> gestionnaireUtilisateur =
            p_serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            RoleManager<IdentityRole> gestionnaireRôle =
            p_serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string nomUtilisateur = p_configuration["Données:UtilsateurAdmin:Nom"] ?? "AdminI";
            string courriel
            = p_configuration["Données:UtilsateurAdmin:Courriel"] ?? "AdminI@toto.com";
            string MDP = p_configuration["Données:UtilsateurAdmin:MDP"] ?? "InimdA23";
            string rôle = p_configuration["Données:UtilsateurAdmin:Rôle"] ?? "Administrateur";
            if (await gestionnaireUtilisateur.FindByNameAsync(nomUtilisateur) == null)
            {
                if (await gestionnaireRôle.FindByNameAsync(rôle) == null)
                {
                    await gestionnaireRôle.CreateAsync(new IdentityRole(rôle));
                }
                IdentityUser utilisateur = new IdentityUser
                {
                    UserName = nomUtilisateur,
                    Email = courriel
                };
                IdentityResult résultat = await gestionnaireUtilisateur
                .CreateAsync(utilisateur, MDP);
                if (résultat.Succeeded)
                {
                    await gestionnaireUtilisateur.AddToRoleAsync(utilisateur, rôle);
                }
            }
        }
    }
}
