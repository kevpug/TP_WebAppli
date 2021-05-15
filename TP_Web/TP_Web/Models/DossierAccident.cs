using System.ComponentModel.DataAnnotations;

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
