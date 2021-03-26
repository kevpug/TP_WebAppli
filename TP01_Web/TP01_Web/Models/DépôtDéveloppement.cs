using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP01_Web.Models
{
    public class DépôtDéveloppement : IDépôt, ReadMe
    {
        private List<Utilisateur> utilisateurs = new List<Utilisateur>();

        public static bool UtilisateurConnecté { get; set; }

        public DépôtDéveloppement()
        {
            utilisateurs.Add(new Utilisateur {
                NomUtilisateur = "AdminI",
                MotDePasse= "Inimda23"
            });
        }
        public void AjouterUtilisateur(Utilisateur p_utilisateur)
        {
            utilisateurs.Add(p_utilisateur);
        }
        public IEnumerable<Utilisateur> Utilisateurs => utilisateurs.AsQueryable<Utilisateur>();


    }
}
