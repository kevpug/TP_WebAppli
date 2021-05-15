using System;

namespace TP_Web.Models
{
    public sealed class LocationVoitureModèle
    {
        public long? CodeSuccursale { get; set; }
        public string Modèle { get; set; }
        public long? NuméroVoiture { get; set; }
        public int? NombreJoursLocation { get; set; }
        public long? CodeSuccursaleRetour { get; set; }
        public DateTime DateLocation { get; set; }
        public string NuméroPermisConduire { get; set; }
        public string Prénom { get; set; }
        public string Nom { get; set; }
        public string NuméroTéléphone { get; set; }
    }
}
