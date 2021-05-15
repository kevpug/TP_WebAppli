﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey("VoitureId")]
        public Voiture Voiture { get; set; }
        [ForeignKey("ClientId")]
        public Client Client { get; set; }

    }
}
