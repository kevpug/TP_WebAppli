using Microsoft.AspNetCore.Mvc;

namespace TP01_Web.Controllers
{
    public class HomeController : Controller, ReadMe
    {
        public IActionResult Index()
        {
            ViewBag.Noms = "Arnaud Labrecque & Kevin Pugliese";
            ViewBag.Title = "Accueil";
            return View();
        }
    }
}
