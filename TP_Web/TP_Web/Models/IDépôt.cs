using System.Collections.Generic;

namespace TP01_Web.Models
{
    public interface IDépôt : ReadMe
    {
        IEnumerable<UtilisateurModèle> Utilisateurs { get; }
        void AjouterUtilisateur(UtilisateurModèle p_utilisateur);
    }
}
