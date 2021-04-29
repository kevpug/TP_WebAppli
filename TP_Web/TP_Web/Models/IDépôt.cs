using System.Collections.Generic;

namespace TP01_Web.Models
{
    public interface IDépôt : ReadMe
    {
        IEnumerable<Utilisateur> Utilisateurs { get; }
        void AjouterUtilisateur(Utilisateur p_utilisateur);
    }
}
