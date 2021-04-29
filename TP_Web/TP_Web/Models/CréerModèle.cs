using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TP_Web.Models
{
    public class CréerModèle
    {
        [Required]
        public string Nom { get; set; }
        [Required]
        public string Courriel { get; set; }
        [Required]
        public string MDP { get; set; }
    }
}
