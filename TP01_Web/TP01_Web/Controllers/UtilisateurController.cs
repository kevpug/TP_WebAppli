using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP01_Web.Controllers
{
    public class UtilisateurController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
