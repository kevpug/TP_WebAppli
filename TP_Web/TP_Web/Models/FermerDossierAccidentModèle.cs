using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP_Web.Models
{
    public class FermerDossierAccidentModèle
    {
        public int? DossierID { get; set; }
        public string NuméroPermisConduire { get; set; }
        public long? NuméroVoiture { get; set; }

    }
}
