using System.Linq;

namespace TP_Web.Models
{
    public interface IDépôt : ReadMe
    {
        //IEnumerable<Utilisateur> Utilisateurs { get; }
        // void AjouterUtilisateur(Utilisateur p_utilisateur);
        IQueryable<Succursale> Succursales { get; }
        IQueryable<Voiture> Voitures { get; }
        void AjouterSuccursale(Succursale p_succursale);
        void EffacerSuccursale(Succursale p_succursale);
        void AjouterVoiture(Voiture p_voiture);
        void EffacerVoiture(Voiture p_voiture);

    }
}
