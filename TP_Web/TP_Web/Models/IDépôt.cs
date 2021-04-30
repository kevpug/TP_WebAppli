using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace TP_Web.Models
{
    public interface IDépôt : ReadMe
    {
        IQueryable<IdentityUser> Utilisateurs { get; }
        IQueryable<Succursale> Succursales { get; }
        IQueryable<Voiture> Voitures { get; }
        void AjouterSuccursale(Succursale p_succursale);
        void AjouterVoiture(Voiture p_voiture);

    }
}
