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
            if (string.IsNullOrEmpty(p_utilisateur.NomUtilisateur))
                ModelState.AddModelError(nameof(Utilisateur.NomUtilisateur), "Entrez un nom d'utilisateur.");
            if (ModelState.IsValid)
            {
                return View("Index");
            }
            else
                return View();
        }

        public IActionResult Résultats()
        {
            return View(TempData);
        }
    }
}
