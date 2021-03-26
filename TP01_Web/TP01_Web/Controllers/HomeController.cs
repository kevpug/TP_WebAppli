using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TP01_Web.Models;

namespace TP01_Web.Controllers
{
    public class HomeController : Controller
    {
        private IDépôt dépôt;
        public HomeController(IDépôt p_dépôt)
        {
            dépôt = p_dépôt;
        }
        public IActionResult Index()
        {
            //return View("Index");
            ViewBag.Noms = "Arnaud Labrecque & Kevin Pugliese";
            return View(dépôt.Utilisateurs);
        }
    }
}
