using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
            ViewBag.Title = "Page d'authentification";
            ViewBag.Noms = "Arnaud Labrecque & Kevin Pugliese";
            return View();
        }

        [HttpPost]
        public IActionResult Authentification(Utilisateur p_utilisateur)
        {
            ViewBag.Title = "Page d'authentification";
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
                return View("../Home/Index");
            }
            else
                return View();
        }

        public IActionResult AjouterUtilisateur()
        {
            ViewBag.Title = "Création d'un utilisateur";
            ViewBag.Noms = "Arnaud Labrecque & Kevin Pugliese";
            return View();
        }

        [HttpPost]
        public IActionResult AjouterUtilisateur(Utilisateur p_utilisateur)
        {
            ViewBag.Noms = "Arnaud Labrecque & Kevin Pugliese";
            ViewBag.Title = "Création d'un utilisateur";

            if (string.IsNullOrEmpty(p_utilisateur.NomUtilisateur))
                ModelState.AddModelError(nameof(Utilisateur.NomUtilisateur), "Entrez un nom d'utilisateur.");
            else
            {
                if (!Regex.Match(p_utilisateur.NomUtilisateur, @"^([a-zA-Z0-9]){6}$").Success)
                    ModelState.AddModelError(nameof(Utilisateur.NomUtilisateur), "Entrez un nom d'utilisateur valide. (6 caractères, lettres et chiffres obligatoire)");
            }

            if (dépôt.Utilisateurs.Any(u => u.NomUtilisateur == p_utilisateur.NomUtilisateur))
                ModelState.AddModelError(nameof(Utilisateur.NomUtilisateur), "Entrez un nom d'utilisateur qui n'existe pas déjà.");


            if (string.IsNullOrEmpty(p_utilisateur.MotDePasse))
                ModelState.AddModelError(nameof(Utilisateur.MotDePasse), "Entrez un mot de passe.");
            else
            {
                if (!Regex.Match(p_utilisateur.MotDePasse, @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8}$").Success)
                    ModelState.AddModelError(nameof(Utilisateur.MotDePasse), "Entrez un mot de passe valide. (8 caractères, lettres et chiffres obligatoire)");
            }

            if (p_utilisateur.Rôle == Utilisateur.TypeUtilisateur.Administrateur) //Si le choix est "Choisissez un rôle" retourne Administrateur
                ModelState.AddModelError(nameof(Utilisateur.Rôle), "Choisissez un type d'utilisateur."); //Alors on valide s'il n'est pas Admin.


            if (ModelState.IsValid)
            {
                dépôt.AjouterUtilisateur(p_utilisateur);
                return View("../Home/Index");
            }
            else
                return View();

        }
    }
}
