﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP_Web.Models
{
    public sealed class ChoisirVoitureDispo
    {
        public long? CodeSuccursale { get; set; }
        public string Modèle { get; set; }
        public long? NuméroVoiture { get; set; }
        public int NombreJoursLocation { get; set; }
        public long? CodeSuccursaleRetour { get; set; }
        public DateTime DateLocation { get; set; }
        public string NuméroPermisConduire { get; set; }
    }
}
