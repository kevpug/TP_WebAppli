using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP01_Web.Models
{
    public interface IDépôt : ReadMe
    {
        IEnumerable<Utilisateur> Utilisateurs { get; }
        void AjouterUtilisateur(Utilisateur p_utilisateur);
    }
}
