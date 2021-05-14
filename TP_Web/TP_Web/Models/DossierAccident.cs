using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TP_Web.Models
{
    public sealed class DossierAccident
    {
        [Key]
        public int DossierID { get; set; }

        public string RapportAccident { get; set; }

        public bool DossierFermé { get; set; }


        public Client Client { get; set; }

        public Voiture Voiture { get; set; }
    }
}
