using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TP_Web.Models;

namespace TP_Web.Controllers
{
    public class SuccursaleController : Controller
    {

        private IDépôt dépôt;

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

            if (ModelState.IsValid)
            {
                dépôt.AjouterSuccursale(p_succursale);
            }

            return View();
        }

    }
}
