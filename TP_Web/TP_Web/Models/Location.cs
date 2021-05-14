using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TP_Web.Models
{
    public sealed class Location
    {
        [Key]
        public int LocationId { get; set; }

        public int NombreJoursLocation { get; set; }
        public DateTime DateDeLocation { get; set; }

        public Succursale SuccursaleDeRetour { get; set; }
        public Voiture Voiture { get; set; }
        public Client Client { get; set; }

    }
}
