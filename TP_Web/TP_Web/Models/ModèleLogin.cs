using System.ComponentModel.DataAnnotations;

namespace TP_Web.Models
{
    public class ModèleLogin : ReadMe
    {
        [Required(ErrorMessage = "Veuillez entrer un code d'utilisateur.")]
        [UIHint("Code utilisateur")]
        public string CodeUtilisateur { get; set; }
        [Required(ErrorMessage = "Veuillez entrer un mot de passe.")]
        [UIHint("Mot de passe")]
        public string MDP { get; set; }
    }
}
