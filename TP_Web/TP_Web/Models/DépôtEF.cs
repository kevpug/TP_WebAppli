using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

        public static string utilisateurName { get; set; }

        public IQueryable<Succursale> Succursales => contexteAutoLoco.Succursales;
        public IQueryable<IdentityUser> Utilisateurs => contexteIdendité.Users;
        public IQueryable<Voiture> Voitures => contexteAutoLoco.Voitures;
        public IQueryable<Location> Locations => contexteAutoLoco.Locations.Include(v => v.Voiture).Include(s => s.SuccursaleDeRetour).Include(c => c.Client);
        public IQueryable<Client> Clients => contexteAutoLoco.Clients;
        public IQueryable<DossierAccident> DossierAccidents => contexteAutoLoco.DossierAccidents;


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
        public void AjouterLocation(Location p_location)
        {
            p_location.Voiture.EstDisponible = false;
            contexteAutoLoco.Locations.Add(p_location);
            contexteAutoLoco.SaveChanges();
        }
        public void AjouterClient(Client p_client)
        {
            contexteAutoLoco.Clients.Add(p_client);
            contexteAutoLoco.SaveChanges();
        }
        public void AjouterDossier(DossierAccident p_dossier)
        {
            contexteAutoLoco.DossierAccidents.Add(p_dossier);
            contexteAutoLoco.SaveChanges();
        }

        public void RetourVoiture(long? NoVoiture, long? codeSuccursale)
        {
            var voiture = contexteAutoLoco.Voitures.Find(NoVoiture);
            voiture.EstDisponible = true;
            var succursale = contexteAutoLoco.Succursales.Find(codeSuccursale);
            voiture.Succursale = succursale;

            contexteAutoLoco.SaveChanges();
        }
    }
}
