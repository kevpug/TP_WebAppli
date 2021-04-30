using System.Collections.Generic;
using System.Linq;

namespace TP_Web.Models
{
    public class DépôtEF : IDépôt, ReadMe
    {

        private ContexteLocoAuto contexte;
        public DépôtEF(ContexteLocoAuto p_contexte)
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
        public void EffacerSuccursale(Succursale p_succursale)
        {
            contexte.Succursales.Remove(p_succursale);
            contexte.SaveChanges();
        }
        public void AjouterVoiture(Voiture p_voiture)
        {
            contexte.Voitures.Add(p_voiture);
            contexte.SaveChanges();
        }
        public void EffacerVoiture(Voiture p_voiture)
        {
            contexte.Voitures.Remove(p_voiture);
            contexte.SaveChanges();
        }


    }
}
