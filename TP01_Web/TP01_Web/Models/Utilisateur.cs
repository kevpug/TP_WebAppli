using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TP01_Web.Models
{
    public sealed class Utilisateur
    {
        public enum TypeUtilisateur {Administrateur, Gérant, Commis }

        public string NomUtilisateur { get; set; }

        public string MotDePasse { get; set; }
        public TypeUtilisateur Rôle { get; set; }
    }
}
