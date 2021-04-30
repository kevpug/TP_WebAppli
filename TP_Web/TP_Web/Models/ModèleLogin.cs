using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TP_Web.Models
{
    public class ModèleLogin : ReadMe
    {
        [Required]
        [UIHint("Username")]
        public string NomUtilisateur { get; set; }
        [Required]
        [UIHint("Mot de passe")]
        public string MDP { get; set; }
    }
}
