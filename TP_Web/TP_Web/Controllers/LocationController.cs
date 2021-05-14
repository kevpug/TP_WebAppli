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

            List<string> TempDataModele = new List<string>();
            TempDataModele.Add(p_lvm.Modèle);
            TempDataModele.Add(p_lvm.CodeSuccursale.ToString());
            TempData["LocationInfo"] = TempDataModele;

            //return View("VoituresDispo", p_lvm);
            return RedirectToAction("VoituresDispo"); // A decommenter pour avoir le redirect sur l'action du VoitureDispo
        }

        [HttpGet]
        [Authorize(Roles = "Gerant, Commis")]
        public IActionResult VoituresDispo()
        {
            IEnumerable<string> locationInfo = (IEnumerable<string>)TempData["LocationInfo"];
            string Modèle = locationInfo.ElementAt(0);
            string CodeSuccursale = locationInfo.ElementAt(1);

            //Tu peux faire des viewBags pour afficher maintenant à l'aide du TempData

            var succursale = new Succursale();

            try
            {
                ViewBag.ListeSuccursales = dépôt.Succursales;
                ViewBag.ListeNumeroVoitures = dépôt.Voitures.Where(s => s.Modèle == Modèle && s.Succursale.CodeSuccursale.ToString() == CodeSuccursale && s.EstDisponible)
                .Select(v => v.NuméroVoiture);
            }
            catch
            {
                Voiture.GroupeVoiture grpVoiture = (Voiture.GroupeVoiture)dépôt.Voitures.First(v => v.Modèle == Modèle).Groupe;
                ViewBag.ListeNumeroVoitures = dépôt.Voitures.Where(s => s.Groupe == grpVoiture && s.Succursale.CodeSuccursale.ToString() == CodeSuccursale && s.EstDisponible)
                .Select(v => v.NuméroVoiture);
            }
            return View();
        }


        [HttpPost]
        [Authorize(Roles = "Gerant, Commis")]
        public IActionResult VoituresDispo(LocationVoitureModèle p_lvm)
        {

            // Ici tu peux t'en recervir de TempData Je pense qu'il va falloir un get,
            // mais je suis pas encore sûre
            //List<string> TempDataModele = new List<string>();
            //TempData["LocationInfo"] = TempDataModele;
            IEnumerable<string> locationInfo = (IEnumerable<string>)TempData["LocationInfo"];
            string Modèle = locationInfo.ElementAt(0);
            string CodeSuccursale = locationInfo.ElementAt(1);

            //Tu peux faire des viewBags pour afficher maintenant à l'aide du TempData

            var succursale = new Succursale();

            try
            {
                ViewBag.ListeSuccursales = dépôt.Succursales;
                ViewBag.ListeNumeroVoitures = dépôt.Voitures.Where(s => s.Modèle == Modèle && s.Succursale.CodeSuccursale.ToString() == CodeSuccursale && s.EstDisponible)
                .Select(v => v.NuméroVoiture);
                //.Where(v => v.EstDisponible && v.Modèle == p_lvm.Modèle)


            }
            catch
            {
                Voiture.GroupeVoiture grpVoiture = (Voiture.GroupeVoiture)dépôt.Voitures.First(v => v.Modèle == Modèle).Groupe;
                ViewBag.ListeNumeroVoitures = dépôt.Voitures.Where(s => s.Groupe == grpVoiture && s.Succursale.CodeSuccursale.ToString() == CodeSuccursale && s.EstDisponible)
                .Select(v => v.NuméroVoiture); 
            }
            return View(p_lvm);
        }

    }
}
