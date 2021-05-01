using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text.RegularExpressions;
using TP_Web.Models;

namespace TP_Web.Controllers
{
    public class SuccursaleController : Controller, ReadMe
    {

        private IDépôt dépôt;

        public SuccursaleController(IDépôt p_dépôt)
        {
            dépôt = p_dépôt;
        }


        [HttpGet]
        [Authorize(Roles = "Gerant")]
        public ViewResult AjouterSuccursale()
        {
            ViewBag.Noms = "Arnaud Labrecque & Kevin Pugliese";
            ViewBag.User = HttpContext.User.Identity.Name;
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Gerant")]
        public IActionResult AjouterSuccursale(Succursale p_succursale)
        {
            ViewBag.Noms = "Arnaud Labrecque & Kevin Pugliese";
            ViewBag.User = HttpContext.User.Identity.Name;

            if (dépôt.Succursales.Any(s => s.CodeSuccursale == p_succursale.CodeSuccursale))
                ModelState.AddModelError(nameof(Succursale.CodeSuccursale), "Ce numéro de Succursale existe déjà!");

            if (p_succursale.CodeSuccursale < 0)
                ModelState.AddModelError(nameof(Succursale.CodeSuccursale), "Le code de succursale doit être positif.");

            if (p_succursale.NuméroCivique < 0)
                ModelState.AddModelError(nameof(Succursale.NuméroCivique), "Le numéro civique doit être positif.");

            if (!string.IsNullOrEmpty(p_succursale.CodePostal))
                if (!Regex.Match(p_succursale.CodePostal, @"^[a-zA-Z][0-9][a-zA-Z][0-9][a-zA-Z][0-9]$").Success)
                    ModelState.AddModelError(nameof(Succursale.CodePostal), "Veuillez fournir un code postal dans un format valide (LCLCLC).");

            if (!string.IsNullOrEmpty(p_succursale.NuméroTéléphone))
                if (!Regex.Match(p_succursale.NuméroTéléphone, @"^[\d][\d][\d][\d][\d][\d][\d][\d][\d][\d]$").Success)
                ModelState.AddModelError(nameof(Succursale.NuméroTéléphone), "Veuillez fournir un numéro de téléphone valide.");


            if (dépôt.Succursales.Any(s => s.NomRue == p_succursale.NomRue && s.CodePostal == p_succursale.CodePostal))
            {
                ModelState.AddModelError(nameof(Succursale.NomRue), "Il y a déjà une succursale avec le même nom de rue et code postal");
                ModelState.AddModelError(nameof(Succursale.CodePostal), "Il y a déjà une succursale avec le même nom de rue et code postal");
            }

            if (dépôt.Succursales.Any(s => s.NomVille != p_succursale.NomVille && s.CodePostal == p_succursale.CodePostal))
            {
                ModelState.AddModelError(nameof(Succursale.NomVille), "Il y a un autre nom de ville avec le même code postal");
                ModelState.AddModelError(nameof(Succursale.CodePostal), "Il y a un autre nom de ville avec le même code postal");
            }

            if (dépôt.Succursales.Any(s => s.NomProvince != p_succursale.NomProvince && s.CodePostal == p_succursale.CodePostal))
            {
                ModelState.AddModelError(nameof(Succursale.NomProvince), "Il y a un autre nom de province avec le même code postal");
                ModelState.AddModelError(nameof(Succursale.CodePostal), "Il y a un autre nom de province avec le même code postal");
            }

            if (ModelState.IsValid)
            {
                dépôt.AjouterSuccursale(p_succursale);
                return View("../Home/Index");
            }

            return View();
        }

    }
}
