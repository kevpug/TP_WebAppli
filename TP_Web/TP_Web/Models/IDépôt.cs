using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace TP_Web.Models
{
    public interface IDépôt : ReadMe
    {
        public static bool UtilisateurConnecté { get; set; }
        public static string utilisateurName { get; set; }
        IQueryable<IdentityUser> Utilisateurs { get; }
        IQueryable<Succursale> Succursales { get; }
        IQueryable<Voiture> Voitures { get; }
        IQueryable<Client> Clients { get; }
        IQueryable<Location> Locations { get; }
        void AjouterSuccursale(Succursale p_succursale);
        void AjouterVoiture(Voiture p_voiture);

    }
}
