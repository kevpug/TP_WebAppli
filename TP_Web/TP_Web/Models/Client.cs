using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TP_Web.Models
{
    public sealed class Client
    {
        [Key]
        public long? ClientId { get; set; }
        public string NuméroPermisConduire { get; set; }
        public string Prénom { get; set; }
        public string Nom { get; set; }
        public string NuméroTéléphone { get; set; }
        public Location Location { get; set; }

    }
}
