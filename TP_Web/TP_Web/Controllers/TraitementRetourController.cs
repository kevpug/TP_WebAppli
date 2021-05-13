using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TP_Web.Models;

namespace TP_Web.Controllers
{
    public class TraitementRetourController : Controller
    {
        private IDépôt dépôt;

        public TraitementRetourController(IDépôt p_dépôt)
        {
            dépôt = p_dépôt;
        }

        public IActionResult RetournerVoiture()
        {
            ViewBag.Noms = "Arnaud Labrecque & Kevin Pugliese";
            return View();
        }
    }
}
