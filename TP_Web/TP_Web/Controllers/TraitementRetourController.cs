using Microsoft.AspNetCore.Authorization;
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

        [HttpGet]
        [Authorize(Roles = "Gerant, Commis")]
        public ViewResult RetournerVoiture()
        {
            ViewBag.Noms = "Arnaud Labrecque & Kevin Pugliese";
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Gerant, Commis")]
        public IActionResult RetournerVoiture(Voiture p_voiture)
        {
            ViewBag.Noms = "Arnaud Labrecque & Kevin Pugliese";


            return View();
        }
    }
}
