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
            if (string.IsNullOrEmpty(p_utilisateur.NomUtilisateur))
                ModelState.AddModelError(nameof(Utilisateur.NomUtilisateur), "Entrez un nom d'utilisateur.");
            if (string.IsNullOrEmpty(p_utilisateur.MotDePasse))
                ModelState.AddModelError(nameof(Utilisateur.MotDePasse), "Entrez un mot de passe.");
            if (dépôt.Utilisateurs.Any(u => u.NomUtilisateur == p_utilisateur.NomUtilisateur))
            {
                if (!dépôt.Utilisateurs.Any(u => u.NomUtilisateur == p_utilisateur.NomUtilisateur && u.MotDePasse == p_utilisateur.MotDePasse))
                    ModelState.AddModelError(nameof(Utilisateur.MotDePasse), "Le mot de passe est incorrect.");
            }
            else
                ModelState.AddModelError(nameof(Utilisateur.NomUtilisateur), "Le nom d'utilisateur entré n'existe pas.");

            if (ModelState.IsValid)
            {
                DépôtDéveloppement.UtilisateurConnecté = true;
                return View("../Utilisateur/Index"); // Ici on voudrait peut-être se connecter à l'index des utilisateurs pour voir Les Users Identity
            }
            else
                return View();
            return View();
        }

        //public IActionResult AjouterVoiture(Voiture voiture)
        //{
        //    dépôt.AjouterVoiture(voiture);
        //    return View();
        //}

        //[HttpPost]
        //public Task<IActionResult> AjouterVoiture(Voiture p_voiture)
        //{
        //   dépôt.AjouterVoiture(p_voiture);
        //    //return View(p_voiture);
        //}
    }
}
