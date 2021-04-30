using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TP_Web.Controllers
{
    public class HomeController : Controller, ReadMe
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            ViewBag.Noms = "Arnaud Labrecque & Kevin Pugliese";
            ViewBag.User = HttpContext.User.Identity.Name;
            return View();
        }
    }
}
