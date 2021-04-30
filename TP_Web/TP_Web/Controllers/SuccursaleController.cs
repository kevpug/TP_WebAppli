using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TP_Web.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

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

            if (dépôt.Succursales.Any(s => s.CodeSuccursale == p_succursale.CodeSuccursale))
                ModelState.AddModelError(nameof(Succursale.CodeSuccursale), "Ce numéro de Succursale existe déjà!");

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
