using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TP_Web.Models;

namespace TP_Web.Controllers
{
    public class VoitureController : Controller, ReadMe
    {
        private IDépôt dépôt;
        public VoitureController(IDépôt p_dépôt)
        {
            dépôt = p_dépôt;
        }

        [HttpGet]
        [Authorize(Roles = "Gerant, Commis")]
        public ViewResult AjouterVoiture()
        {
            ViewBag.Noms = "Arnaud Labrecque & Kevin Pugliese";
            ViewBag.User = HttpContext.User.Identity.Name;
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Gerant, Commis")]
        public IActionResult AjouterVoiture(CréerVoitureModèle p_voiture)
        {
            ViewBag.Noms = "Arnaud Labrecque & Kevin Pugliese";

            if (dépôt.Voitures.Any(v => v.NuméroVoiture == p_voiture.NuméroVoiture))
                ModelState.AddModelError(nameof(CréerVoitureModèle.NuméroVoiture), "Le numéro de la voiture existe déjà.");
            if (dépôt.Voitures.Any(v => v.Modèle == p_voiture.Modèle &&
                                        v.Groupe != p_voiture.Groupe))
            {
                string sNomGroupe = dépôt.Voitures.First(v => v.Modèle == p_voiture.Modèle &&
                                        v.Groupe != p_voiture.Groupe).Groupe.ToString();
                ModelState.AddModelError(nameof(CréerVoitureModèle.Modèle), $"Le modèle de la voiture existe déjà pour le groupe {sNomGroupe}.");
            }
            if (!dépôt.Succursales.Any(v => v.CodeSuccursale == p_voiture.Succursale))
                ModelState.AddModelError(nameof(CréerVoitureModèle.Succursale), "Aucune succursale est associée au code saisie.");

            if (ModelState.IsValid)
            {
                Voiture NouvelleVoiture = new Voiture()
                {
                    NuméroVoiture = p_voiture.NuméroVoiture,
                    Modèle = p_voiture.Modèle,
                    EstDisponible = true,
                    Année = p_voiture.Année,
                    Millage = p_voiture.Millage,
                    Groupe = p_voiture.Groupe,
                    Succursale = dépôt.Succursales.First(v => v.CodeSuccursale == p_voiture.Succursale)
                };
                dépôt.AjouterVoiture(NouvelleVoiture);
                return View("../Home/Index");
            }
            return View();
        }
    }
}
