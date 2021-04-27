using System.Collections.Generic;
using System.Linq;

namespace TP01_Web.Models
{
    public class DépôtDéveloppement : IDépôt, ReadMe
    {
        private List<UtilisateurModèle> utilisateurs = new List<UtilisateurModèle>();

        public static bool UtilisateurConnecté { get; set; }

        public DépôtDéveloppement()
        {
            utilisateurs.Add(new UtilisateurModèle {
                NomUtilisateur = "AdminI",
                MotDePasse= "Inimda23"
            });
        }
        public void AjouterUtilisateur(UtilisateurModèle p_utilisateur)
        {
            utilisateurs.Add(p_utilisateur);
        }
        public IEnumerable<UtilisateurModèle> Utilisateurs => utilisateurs.AsQueryable<UtilisateurModèle>();


    }
}
