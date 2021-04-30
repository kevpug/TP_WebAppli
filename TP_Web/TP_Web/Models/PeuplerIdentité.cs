using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP_Web.Models
{
    public class PeuplerIdentité : ReadMe
    {

        public static void CréerCompteBD(IServiceProvider p_serviceProvider,
                                            IConfiguration p_configuration)
        {
            CréerCompteGérantAsync(p_serviceProvider, p_configuration).Wait();
            CréerCompteCommisAsync(p_serviceProvider, p_configuration).Wait();
            CréerCompteUtilisateurAsync(p_serviceProvider, p_configuration).Wait();
        }
        public static async Task CréerCompteGérantAsync(IServiceProvider p_serviceProvider,
                                                       IConfiguration p_configuration)
        {
            p_serviceProvider = p_serviceProvider.CreateScope().ServiceProvider;
            UserManager<IdentityUser> gestionnaireUtilisateur =
            p_serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            RoleManager<IdentityRole> gestionnaireRôle =
            p_serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string nomUtilisateur = p_configuration["Données:UtilsateurAdmin:Nom"] ?? "AdminI";
            string courriel= p_configuration["Données:UtilsateurAdmin:Courriel"] ?? "AdminI@toto.com";
            string MDP = p_configuration["Données:UtilsateurAdmin:MDP"] ?? "InimdA23";
            string rôle = p_configuration["Données:UtilsateurAdmin:Rôle"] ?? "Gérant";
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

        public static async Task CréerCompteCommisAsync(IServiceProvider p_serviceProvider,
                                               IConfiguration p_configuration)
        {
            p_serviceProvider = p_serviceProvider.CreateScope().ServiceProvider;
            UserManager<IdentityUser> gestionnaireUtilisateur =
            p_serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            RoleManager<IdentityRole> gestionnaireRôle =
            p_serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string nomUtilisateur = p_configuration["Données:UtilsateurAdmin:Nom"] ?? "CommisI";
            string courriel = p_configuration["Données:UtilsateurAdmin:Courriel"] ?? "CommisI@toto.com";
            string MDP = p_configuration["Données:UtilsateurAdmin:MDP"] ?? "SimmoC23";
            string rôle = p_configuration["Données:UtilsateurAdmin:Rôle"] ?? "Commis";
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

        public static async Task CréerCompteUtilisateurAsync(IServiceProvider p_serviceProvider,
                                               IConfiguration p_configuration)
        {
            p_serviceProvider = p_serviceProvider.CreateScope().ServiceProvider;
            UserManager<IdentityUser> gestionnaireUtilisateur =
            p_serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            RoleManager<IdentityRole> gestionnaireRôle =
            p_serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string nomUtilisateur = p_configuration["Données:UtilsateurAdmin:Nom"] ?? "UtilisateurI";
            string courriel = p_configuration["Données:UtilsateurAdmin:Courriel"] ?? "Utilisateur@toto.com";
            string MDP = p_configuration["Données:UtilsateurAdmin:MDP"] ?? "RuetasilitU23";
            string rôle = p_configuration["Données:UtilsateurAdmin:Rôle"] ?? "Utilisateur";
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
