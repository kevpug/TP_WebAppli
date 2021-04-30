using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TP_Web.Controllers
{
    public class HomeController : Controller, ReadMe
    {
        public IActionResult Index()
        {
            ViewBag.Noms = "Arnaud Labrecque & Kevin Pugliese";
            return View(ObtenirDonnées(nameof(Index)));
        }

        [Authorize(Roles = "Utilisateurs")]
        public IActionResult AutreAction() => View("Index",
            ObtenirDonnées(nameof(AutreAction)));

        private Dictionary<string, object> ObtenirDonnées(string actionName) =>
    new Dictionary<string, object>
    {
        ["Action"] = actionName,
        ["Utilisateur"] = HttpContext.User.Identity.Name,
        ["Authentifié ?"] = HttpContext.User.Identity.IsAuthenticated,
        ["Type d'authentification"] = HttpContext.User.Identity.AuthenticationType,
        ["Rôle"] = HttpContext.User.IsInRole("Utilisateurs")
    };
    }
}
