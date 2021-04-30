using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TP_Web.Models;

namespace TP_Web.Controllers
{
    public class VoitureController : Controller
    {
        private IDépôt dépôt;
        public VoitureController(IDépôt p_dépôt)
        {
            dépôt = p_dépôt;
        }

        public IActionResult Index()
        {
            ViewBag.Noms = "Arnaud Labrecque & Kevin Pugliese";
            return View();
        }

        [HttpGet]
        public ViewResult AjouterVoiture()
        {
            ViewBag.Noms = "Arnaud Labrecque & Kevin Pugliese";
            return View();
        }

        [HttpPost]
        public ViewResult AjouterVoiture(CréerVoitureModèle p_voiture)
        {
            ViewBag.Noms = "Arnaud Labrecque & Kevin Pugliese";

            if (dépôt.Voitures.Any(v => v.VoitureId == p_voiture.VoitureId))
                ModelState.AddModelError(nameof(CréerVoitureModèle.VoitureId), "Le numéro de la voiture existe déjà.");
            if (dépôt.Voitures.Any(v => v.Modèle == p_voiture.Modèle &&
                                        v.Groupe != p_voiture.Groupe))
            {
                string sNomGroupe = dépôt.Voitures.First(v => v.Modèle == p_voiture.Modèle &&
                                        v.Groupe != p_voiture.Groupe).Groupe.ToString();
                ModelState.AddModelError(nameof(CréerVoitureModèle.Modèle), $"Le modèle de la voiture existe déjà pour le groupe {sNomGroupe}.");
            }
            //}
            //else
            //    ModelState.AddModelError(nameof(Utilisateur.NomUtilisateur), "Le nom d'utilisateur entré n'existe pas.");

            if (ModelState.IsValid)
            {
                DépôtDéveloppement.UtilisateurConnecté = true;
                return View("../Utilisateur/Index");
            }
            return View();
        }
    }
}
