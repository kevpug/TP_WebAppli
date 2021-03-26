using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP01_Web.Models
{
    public class DépôtDéveloppement : IDépôt
    {
        private List<Utilisateur> utilisateurs = new List<Utilisateur>();

        public DépôtDéveloppement()
        {
            utilisateurs.Add(new Utilisateur {
                NomUtilisateur = "AdminI",
                MotDePasse= "Inimda23"
            });
        }
        public IEnumerable<Utilisateur> Utilisateurs => utilisateurs.AsQueryable<Utilisateur>();

        public void AjouterUtilisateur(Utilisateur p_utilisateur)
        {
            utilisateurs.Add(p_utilisateur);
        }
    }
}
