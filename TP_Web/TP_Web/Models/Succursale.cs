using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TP_Web.Models
{
    public sealed class Succursale
    {
        [Key]
        public int SuccursaleId { get; set; }
        [Required(ErrorMessage = "Veuillez fournir un numéro de succursale")]
        [Range(0, long.MaxValue,
        ErrorMessage = "Le numéro de voiture doit être un chiffre positif.")]
        public long? CodeSuccursale { get; set; }
        [Required(ErrorMessage = "Veuillez fournir un numéro civique")]
        [Range(0, long.MaxValue,
        ErrorMessage = "Le numéro de voiture doit être un chiffre positif.")]
        public long? NuméroCivique { get; set; }
        [Required(ErrorMessage = "Veuillez fournir un nom de rue")]
        public string NomRue { get; set; }
        [Required(ErrorMessage = "Veuillez fournir un nom de ville")]
        public string NomVille { get; set; }
        [Required(ErrorMessage = "Veuillez fournir un nom de province")]
        public string NomProvince { get; set; }
        [Required(ErrorMessage = "Veuillez fournir un code postal")]
        [RegularExpression(@"^[a-zA-Z][0-9][a-zA-Z][0-9][a-zA-Z][0-9]$", ErrorMessage = "Veuillez fournir un code postal dans un format valide (LCLCLC).")]
        public string CodePostal { get; set; }
        [Required(ErrorMessage = "Veuillez fournir un numéro de téléphone")]
        [RegularExpression(@"^[\d][\d][\d][\d][\d][\d][\d][\d][\d][\d]", ErrorMessage = "Veuillez fournir un numéro de téléphone valide")]
        public string NuméroTéléphone { get; set; }


        public IEnumerable<Voiture> Voitures { get; set; }


    }
}
