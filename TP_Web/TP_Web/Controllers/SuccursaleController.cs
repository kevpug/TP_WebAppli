﻿using Microsoft.AspNetCore.Mvc;

namespace TP_Web.Controllers
{
    public class SuccursaleController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Noms = "Arnaud Labrecque & Kevin Pugliese";
            return View();
        }
    }
}