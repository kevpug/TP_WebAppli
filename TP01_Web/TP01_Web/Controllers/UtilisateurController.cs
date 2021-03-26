using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TP01_Web.Models;

namespace TP01_Web.Controllers
{
    public class UtilisateurController : Controller
    {
        IDépôt dépôt;
        public UtilisateurController( IDépôt p_dépôt)
        {
            dépôt = p_dépôt;
        }

        public IActionResult Authentification()
        {
            ViewBag.Noms = "Arnaud Labrecque & Kevin Pugliese";
            return View();
        }

        public IActionResult AjouterUtilisateur()
        {
            ViewBag.Noms = "Arnaud Labrecque & Kevin Pugliese";
            return View();
        }
        [HttpPost]
        public IActionResult Authentification(Utilisateur p_utilisateur)
        {
            ViewBag.Noms = "Arnaud Labrecque & Kevin Pugliese";
            if (string.IsNullOrEmpty(p_utilisateur.NomUtilisateur))
                ModelState.AddModelError(nameof(Utilisateur.NomUtilisateur), "Entrez un nom d'utilisateur.");
            if (string.IsNullOrEmpty(p_utilisateur.MotDePasse))
                ModelState.AddModelError(nameof(Utilisateur.MotDePasse), "Entrez un mot de passe.");
            if (dépôt.Utilisateurs.Any(u => u.NomUtilisateur == p_utilisateur.NomUtilisateur && u.MotDePasse == p_utilisateur.MotDePasse))
            {
                DépôtDéveloppement.UtilisateurConnecté = true;
                return View("../Home/Index");
            }
            else
                return View();
        }

        
    }
}
