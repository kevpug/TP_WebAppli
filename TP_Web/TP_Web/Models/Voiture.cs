using System.ComponentModel.DataAnnotations;

namespace TP_Web.Models
{
    public sealed class Voiture : ReadMe
    {
        public enum GroupeVoiture
        {
            Compact,
            Sedan,
            Luxe
        }

        [Key]
        public long? VoitureId { get; set; }
        public long? NuméroVoiture { get; set; }
        public string Modèle { get; set; }
        public int? Année { get; set; }
        public GroupeVoiture? Groupe { get; set; }
        public long? Millage { get; set; }
        public bool EstDisponible { get; set; }
        public Succursale Succursale { get; set; }
        public Location Location { get; set; }
    }
}
