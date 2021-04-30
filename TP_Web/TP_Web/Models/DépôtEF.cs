using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace TP_Web.Models
{
    public class DépôtEF : IDépôt, ReadMe
    {

        private ContexteAutoLoco contexteAutoLoco;
        private ContexteIdentité contexteIdendité;
        public DépôtEF(ContexteAutoLoco p_autoloco, ContexteIdentité p_identité)
        {
            contexteAutoLoco = p_autoloco;
            contexteIdendité = p_identité;
        }

        public static bool UtilisateurConnecté { get; set; }

        public IQueryable<Succursale> Succursales => contexteAutoLoco.Succursales;
        public IQueryable<IdentityUser> Utilisateurs => contexteIdendité.Users;
        public IQueryable<Voiture> Voitures => contexteAutoLoco.Voitures;
        public void AjouterSuccursale(Succursale p_succursale)
        {
            contexteAutoLoco.Succursales.Add(p_succursale);
            contexteAutoLoco.SaveChanges();
        }
        public void AjouterVoiture(Voiture p_voiture)
        {
            contexteAutoLoco.Voitures.Add(p_voiture);
            contexteAutoLoco.SaveChanges();
        }
    }
}
