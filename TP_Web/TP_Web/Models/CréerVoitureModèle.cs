using System.ComponentModel.DataAnnotations;
using static TP_Web.Models.Voiture;

namespace TP_Web.Models
{
    public sealed class CréerVoitureModèle : ReadMe
    {
        [Required(ErrorMessage = "Veuillez entrer un numéro de voiture.")]
        public long? NuméroVoiture { get; set; }
        [Required(ErrorMessage = "Veuillez entrer un modèle de voiture.")]
        public string Modèle { get; set; }
        [Required(ErrorMessage = "Veuillez entrer une année.")]
        public int? Année { get; set; }
        [Required(ErrorMessage = "Veuillez sélectionner un groupe.")]
        public GroupeVoiture? Groupe { get; set; }
        [Required(ErrorMessage = "Veuillez entrer le millage.")]
        public long? Millage { get; set; }
        [Required(ErrorMessage = "Veuillez entrer le numéro de la succursale.")]
        public long? Succursale { get; set; }
    }
}
