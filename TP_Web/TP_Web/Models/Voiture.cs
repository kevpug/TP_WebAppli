using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TP_Web.Models
{
    public sealed class Voiture
    {
        public enum GroupeVoiture { 
        Compact,
        Sedan,
        Luxe
        }

        [Key]
        public long VoitureId { get; set; }
        public string Modèle { get; set; }
        public int Année { get; set; }
        public GroupeVoiture Groupe { get; set; }

        public long Millage { get; set; }

        public Succursale Succursale { get; set; }


    }
}
