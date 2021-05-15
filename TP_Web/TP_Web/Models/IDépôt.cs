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
        IQueryable<DossierAccident> DossierAccidents { get; }

        void AjouterSuccursale(Succursale p_succursale);
        void AjouterVoiture(Voiture p_voiture);
        void AjouterClient(Client p_client);
        void AjouterLocation(Location p_location);
        void AjouterDossier(DossierAccident p_dossier);
        void RetourVoiture(long? NoVoiture, long? codeSuccursale);
        void FermerDossierAccident(int id);


    }
}
