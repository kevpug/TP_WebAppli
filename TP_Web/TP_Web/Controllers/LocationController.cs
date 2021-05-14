using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TP_Web.Models;

namespace TP_Web.Controllers
{
    public class LocationController : Controller
    {
        private IDépôt dépôt;
        public bool modèleDispo;

        public LocationController(IDépôt p_dépôt)
        {
            dépôt = p_dépôt;
        }


        [HttpGet]
        [Authorize(Roles = "Gerant, Commis")]
        public ViewResult ChoisirModele()
        {
            ViewBag.Noms = "Arnaud Labrecque & Kevin Pugliese";
            ViewBag.ListeSuccursales = dépôt.Succursales;
            try
            {
                ViewBag.ListeModèles = dépôt.Voitures.Select(v => v.Modèle).ToList().Distinct();
            }
            catch
            {
                ViewBag.ListeModèles = new List<string>();
            }

            return View();
        }


        [HttpPost]
        [Authorize(Roles = "Gerant, Commis")]
        public IActionResult ChoisirModele(LocationVoitureModèle p_lvm)
        {
            ViewBag.Noms = "Arnaud Labrecque & Kevin Pugliese";
            ViewBag.ListeSuccursales = dépôt.Succursales;
            try
            {
                ViewBag.ListeModèles = dépôt.Voitures.Select(v => v.Modèle).ToList().Distinct();
            }
            catch
            {
                ViewBag.ListeModèles = new List<string>();
            }



            return View("VoituresDispo", p_lvm);

        }

        [HttpPost]
        [Authorize(Roles = "Gerant, Commis")]
        public IActionResult VoituresDispo(LocationVoitureModèle p_lvm)
        {

            var succursale = new Succursale();

            try
            {
                succursale = dépôt.Succursales.Where(s => s.CodeSuccursale == p_lvm.CodeSuccursale)
                .First();
                ViewBag.ListeNumeroVoitures = succursale.Voitures
                .Where(v => v.EstDisponible && v.Modèle == p_lvm.Modèle)
                .Select(v => v.NuméroVoiture);


            }
            catch
            {
                ViewBag.ListeNumeroVoitures = succursale.Voitures
                .Where(v => v.EstDisponible && v.Modèle == p_lvm.Modèle)
                .Select(v => v.NuméroVoiture); //VA FALLOIR FAIRE CA
            }
            return View(p_lvm);
        }

    }
}
