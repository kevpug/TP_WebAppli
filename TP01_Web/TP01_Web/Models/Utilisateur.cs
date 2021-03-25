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
        [Key]
        public int IdUtilisateur { get; set; }
        public string Prénom { get; set; }
        public string Nom { get; set; }
        public string NomUtilisateur { get; set; }
        public string MotDePasse { get; set; }
    }
}
