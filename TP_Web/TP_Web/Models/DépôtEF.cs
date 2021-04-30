using System.Collections.Generic;
using System.Linq;

namespace TP_Web.Models
{
    public class DépôtEF : IDépôt, ReadMe
    {

        private ContexteAutoLoco contexte;
        public DépôtEF(ContexteAutoLoco p_contexte)
        {
            contexte = p_contexte;
        }

        public static bool UtilisateurConnecté { get; set; }

        public IQueryable<Succursale> Succursales => contexte.Succursales;
        public IQueryable<Voiture> Voitures => contexte.Voitures;
        public void AjouterSuccursale(Succursale p_succursale)
        {
            contexte.Succursales.Add(p_succursale);
            contexte.SaveChanges();
        }
        public void AjouterVoiture(Voiture p_voiture)
        {
            contexte.Voitures.Add(p_voiture);
            contexte.SaveChanges();
        }
    }
}
