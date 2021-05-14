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
        public IActionResult RetournerVoiture(RetourVoitureModèle p_voiture)
        {
            ViewBag.Noms = "Arnaud Labrecque & Kevin Pugliese";

            List<string> TempDataVoiture = new List<string>();
            TempDataVoiture.Add(p_voiture.NuméroVoiture.ToString());
            TempDataVoiture.Add(p_voiture.NouveauMillage.ToString());
            TempDataVoiture.Add(p_voiture.NuméroPermisConduire);
            TempDataVoiture.Add(p_voiture.SuccursaleDeRetour.ToString());

            TempData["VoitureInfo"] = TempDataVoiture;


            return RedirectToAction("FinaliserTraitement");
        }

        [HttpGet]
        [Authorize(Roles = "Gerant, Commis")]
        public ViewResult FinaliserTraitement()
        {
            ViewBag.Noms = "Arnaud Labrecque & Kevin Pugliese";
            return View();
        }

        [HttpPost]
        public IActionResult FinaliserTraitement(RetourVoitureModèle p_voiture)
        {
            IEnumerable<string> voiture = (IEnumerable<string>)TempData["VoitureInfo"];
            long voitureNumero = long.Parse(voiture.First()); // J'ai accès au numéro de la voiture avec ça

            return View();
        }
    }
}
