using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TP01_Web.Models
{
    public sealed class Utilisateur
    {
        enum Type {Administrateur, Gérant, Commis }

        [Required(ErrorMessage = "Entrez votre nom svp.")]
        public string NomUtilisateur { get; set; }

        [Required]
        public string MotDePasse { get; set; }
    }
}
