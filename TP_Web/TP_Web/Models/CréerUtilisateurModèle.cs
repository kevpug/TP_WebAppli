using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TP_Web.Models
{
    public class CréerUtilisateurModèle : ReadMe
    {
        public enum TypeUtilisateur { Utilisateur, Gérant, Commis }

        [Required(ErrorMessage = "Veuillez entrer un code d'utilisateur.")]
        public string CodeUtilisateur { get; set; }
        [Required(ErrorMessage = "Veuillez entrer un courriel.")]
        public string Courriel { get; set; }
        [Required(ErrorMessage = "Veuillez entrer un mot de passe.")]
        public string MDP { get; set; }
        [Required(ErrorMessage = "Veuillez sélectionner un rôle.")]
        public TypeUtilisateur Rôle { get; set; }

    }
}
