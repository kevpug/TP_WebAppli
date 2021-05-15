using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TP_Web.Models;

namespace TP_Web.Controllers
{
    public class DossierAccidentController : Controller
    {
        private IDépôt dépôt;

        public DossierAccidentController(IDépôt p_dépôt)
        {
            dépôt = p_dépôt;
        }

        [HttpGet]
        [Authorize(Roles = "Gerant, Commis")]
        public IActionResult DossierAccident()
        {
            ViewBag.Noms = "Arnaud Labrecque & Kevin Pugliese";
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Gerant, Commis")]
        public IActionResult DossierAccident(FermerDossierAccidentModèle p_fdam)
        {
            ViewBag.Noms = "Arnaud Labrecque & Kevin Pugliese";
            if (p_fdam.DossierID is object)
            {
                if (!dépôt.DossierAccidents.Any(d => d.DossierID == p_fdam.DossierID))
                    ModelState.AddModelError(nameof(FermerDossierAccidentModèle.DossierID), "Ce numéro de dossier d'accident n'existe pas!");
                else
                {
                    if (!string.IsNullOrEmpty(p_fdam.NuméroPermisConduire))
                        if (dépôt.DossierAccidents.First(c => c.DossierID == p_fdam.DossierID).Client.NuméroPermisConduire != p_fdam.NuméroPermisConduire)
                            ModelState.AddModelError(nameof(FermerDossierAccidentModèle.NuméroPermisConduire), "Le numéro de dossier d’accident ne concerne pas une location du client!");
                    if(p_fdam.NuméroVoiture is object)
                        if (dépôt.DossierAccidents.First(c => c.DossierID == p_fdam.DossierID).Voiture.NuméroVoiture != p_fdam.NuméroVoiture)
                            ModelState.AddModelError(nameof(FermerDossierAccidentModèle.NuméroPermisConduire), "Le numéro de dossier d’accident ne concerne pas une location de la voiture identifiée!");
                }
            }
            else
                ModelState.AddModelError(nameof(FermerDossierAccidentModèle.DossierID), "Veuillez entrer un numéro de dossier.");

            if (!string.IsNullOrEmpty(p_fdam.NuméroPermisConduire))
            {
                if (!dépôt.Clients.Any(d => d.NuméroPermisConduire == p_fdam.NuméroPermisConduire))
                    ModelState.AddModelError(nameof(FermerDossierAccidentModèle.NuméroPermisConduire), "Ce numéro de client n'existe pas!");

            }
            else
                ModelState.AddModelError(nameof(FermerDossierAccidentModèle.NuméroPermisConduire), "Veuillez entrer un numéro de client.");

            if (p_fdam.NuméroVoiture is object)
            {
                if (!dépôt.Voitures.Any(d => d.NuméroVoiture == p_fdam.NuméroVoiture))
                    ModelState.AddModelError(nameof(FermerDossierAccidentModèle.NuméroVoiture), "Ce numéro de voiture n'existe pas!");

            }
            else
                ModelState.AddModelError(nameof(FermerDossierAccidentModèle.NuméroVoiture), "Veuillez entrer un numéro de voiture.");


            if (ModelState.IsValid)
            {
                dépôt.FermerDossierAccident((int)p_fdam.DossierID);
                return Redirect("../Home/Index");
            }
            return View(p_fdam);
        }
    }
}
