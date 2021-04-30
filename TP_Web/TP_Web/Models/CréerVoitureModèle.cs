using System.ComponentModel.DataAnnotations;
using static TP_Web.Models.Voiture;

namespace TP_Web.Models
{
    public sealed class CréerVoitureModèle
    {
        [Required(ErrorMessage = "Veuillez entrer un numéro de voiture.")]
        [Range(0, long.MaxValue,
        ErrorMessage = "Le numéro de voiture doit être un chiffre positif.")]
        public long? VoitureId { get; set; }
        [Required(ErrorMessage = "Veuillez entrer un modèle de voiture.")]
        public string Modèle { get; set; }
        [Required(ErrorMessage = "Veuillez entrer une année.")]
        [Range(1900, 9999,
        ErrorMessage = "L'année doit être entre {0} et {1}.")]
        public int? Année { get; set; }
        [Required(ErrorMessage = "Veuillez sélectionner un groupe.")]
        public GroupeVoiture? Groupe { get; set; }

        [Required(ErrorMessage = "Veuillez entrer le millage.")]
        [Range(0, long.MaxValue,
        ErrorMessage = "Le millage doit être un chiffre positif.")]
        public long? Millage { get; set; }

        [Required(ErrorMessage = "Veuillez entrer le numéro de la succursale.")]
        [Range(0, long.MaxValue,
        ErrorMessage = "Le numéro de la succursale doit être un chiffre positif.")]
        public long? Succursale { get; set; }
    }
}
