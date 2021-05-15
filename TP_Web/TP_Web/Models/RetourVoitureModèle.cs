using System.ComponentModel.DataAnnotations;

namespace TP_Web.Models
{
    public class RetourVoitureModèle
    {


        [Required(ErrorMessage = "Veuillez entrer un numéro de voiture.")]
        public long? NuméroVoiture { get; set; }

        [Required(ErrorMessage = "Veuillez entrer un numéro de permis.")]
        public string NuméroPermisConduire { get; set; }


        [Required(ErrorMessage = "Veuillez entrer le millage.")]
        public long? NouveauMillage { get; set; }

        [Required(ErrorMessage = "Veuillez entrer le numéro de la succursale.")]
        public long? SuccursaleDeRetour { get; set; }
    }
}
