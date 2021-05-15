using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TP_Web.Models
{
    public sealed class Succursale : ReadMe
    {
        [Key]
        public int SuccursaleId { get; set; }
        [Required(ErrorMessage = "Veuillez fournir un numéro de succursale")]
        public long? CodeSuccursale { get; set; }
        [Required(ErrorMessage = "Veuillez fournir un numéro civique")]
        public long? NuméroCivique { get; set; }
        [Required(ErrorMessage = "Veuillez fournir un nom de rue")]
        public string NomRue { get; set; }
        [Required(ErrorMessage = "Veuillez fournir un nom de ville")]
        public string NomVille { get; set; }
        [Required(ErrorMessage = "Veuillez fournir un nom de province")]
        public string NomProvince { get; set; }
        [Required(ErrorMessage = "Veuillez fournir un code postal")]
        public string CodePostal { get; set; }
        [Required(ErrorMessage = "Veuillez fournir un numéro de téléphone")]
        public string NuméroTéléphone { get; set; }


        public IEnumerable<Voiture> Voitures { get; set; }

        public IEnumerable<Location> Locations { get; set; }


    }
}
