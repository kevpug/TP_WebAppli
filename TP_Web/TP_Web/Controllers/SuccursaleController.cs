using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TP_Web.Models;
using System.Linq;

namespace TP_Web.Controllers
{
    public class SuccursaleController : Controller
    {

        private IDépôt dépôt;

        public SuccursaleController(IDépôt p_dépôt)
        {
            dépôt = p_dépôt;
        }

        public IActionResult Index()
        {
            ViewBag.Noms = "Arnaud Labrecque & Kevin Pugliese";
            return View();
        }

        [HttpGet]
        public ViewResult AjouterSuccursale()
        {
            ViewBag.Noms = "Arnaud Labrecque & Kevin Pugliese";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AjouterSuccursale(Succursale p_succursale)
        {
            ViewBag.Noms = "Arnaud Labrecque & Kevin Pugliese";

            if (dépôt.Succursales.Any(s => s.SuccursaleId == p_succursale.SuccursaleId))
                ModelState.AddModelError(nameof(Succursale.SuccursaleId), "Ce numéro de Succursale existe déjà!");

            if (dépôt.Succursales.Any(s => s.NomRue == p_succursale.NomRue && s.CodePostal == p_succursale.CodePostal))
            { 
                ModelState.AddModelError(nameof(Succursale.NomRue), "Il ne peut pas y avoir de Succursale à la même rue et code postal");
                ModelState.AddModelError(nameof(Succursale.CodePostal), "Il ne peut pas y avoir de Succursale à la même rue et code postal");
            }

            if (dépôt.Succursales.Any(s => s.NomVille != p_succursale.NomVille && s.CodePostal == p_succursale.CodePostal))
            {
                ModelState.AddModelError(nameof(Succursale.NomVille), "Il ne peut pas y avoir de Succursale à la même rue et code postal");
                ModelState.AddModelError(nameof(Succursale.CodePostal), "Il ne peut pas y avoir de Succursale à la même rue et code postal");
            }

            if (dépôt.Succursales.Any(s => s.NomProvince != p_succursale.NomProvince && s.CodePostal == p_succursale.CodePostal))
            {
                ModelState.AddModelError(nameof(Succursale.NomProvince), "Il ne peut pas y avoir de Succursale à la même province et code postal");
                ModelState.AddModelError(nameof(Succursale.CodePostal), "Il ne peut pas y avoir de Succursale à la même province et code postal");
            }




            if (ModelState.IsValid)
            {
                dépôt.AjouterSuccursale(p_succursale);
            }

            return View();
        }

    }
}
