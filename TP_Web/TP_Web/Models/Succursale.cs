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
        public long SuccursaleId { get; set; }
        public long NuméroCivique { get; set; }
        public string NomRue { get; set; }
        public string NomVille { get; set; }
        public string NomProvince { get; set; }
        public string CodePostal { get; set; }
        public string NuméroTéléphone { get; set; }


        public IEnumerable<Voiture> Voitures { get; set; }


    }
}
