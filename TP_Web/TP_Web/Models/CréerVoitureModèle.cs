using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP_Web.Models
{
    public class CréerVoitureModèle
    {
        public enum GroupeVoiture
        {
            Compact,
            Sedan,
            Luxe
        }

        public long VoitureId { get; set; }
        public string Modèle { get; set; }
        public int Année { get; set; }
        public GroupeVoiture Groupe { get; set; }

        public long Millage { get; set; }

        public long Succursale { get; set; }
    }
}
