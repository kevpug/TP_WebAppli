using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP_Web.Controllers
{
    public class VoitureController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
