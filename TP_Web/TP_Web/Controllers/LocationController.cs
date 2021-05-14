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
            TempDataModele.Add(p_lvm.CodeSuccursale.ToString());
            TempDataModele.Add(p_lvm.Modèle);
            TempData["LocationInfo"] = TempDataModele;

            return RedirectToAction("VoituresDispo");
            //not valid return View(p_lvm);
        }

        [HttpGet]
        [Authorize(Roles = "Gerant, Commis")]
        public IActionResult VoituresDispo()
        {
            IEnumerable<string> locationInfo = (IEnumerable<string>)TempData["LocationInfo"];
            if (locationInfo is null)
                return Redirect("../Location/ChoisirModele"); //Éviter le crash...
            string CodeSuccursale = locationInfo.ElementAt(0);
            ViewBag.CodeSuccursale = CodeSuccursale;
            string Modèle = locationInfo.ElementAt(1);
            ViewBag.Modèle = Modèle;
            List<string> TempDataModele = new List<string>();
            TempDataModele.Add(CodeSuccursale);
            TempDataModele.Add(Modèle);
            TempData["LocationInfo"] = TempDataModele;
           

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

            IEnumerable<string> locationInfo = (IEnumerable<string>)TempData["LocationInfo"];
            if (locationInfo is null)
                return Redirect("../Location/ChoisirModele"); //Éviter le crash...


            List<string> TempDataModele = new List<string>();
            TempDataModele.Add(locationInfo.ElementAt(0));
            TempDataModele.Add(locationInfo.ElementAt(1));
            TempDataModele.Add(p_lvm.NuméroVoiture.ToString());
            TempDataModele.Add(p_lvm.NombreJoursLocation.ToString());
            TempDataModele.Add(p_lvm.CodeSuccursaleRetour.ToString());
            TempDataModele.Add(p_lvm.NuméroPermisConduire.ToString());

            TempData["LocationInfo"] = TempDataModele;
            locationInfo = (IEnumerable<string>)TempData["LocationInfo"];
            string CodeSuccursale = locationInfo.ElementAt(0);
            ViewBag.CodeSuccursale = CodeSuccursale;
            string Modèle = locationInfo.ElementAt(1);
            ViewBag.Modèle = Modèle;

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

            // return View(p_lvm);

            //not valid return View(p_lvm);

            //Valid but client existe pas 
            return RedirectToAction("CréationClientLocation");
        }

        [HttpGet]
        [Authorize(Roles = "Gerant, Commis")]
        public IActionResult CréationClientLocation()
        {
            IEnumerable<string> locationInfo = (IEnumerable<string>)TempData["LocationInfo"];
            if (locationInfo is null)
                return Redirect("../Location/ChoisirModele"); //Éviter le crash...

            ViewBag.CodeSuccursale = locationInfo.ElementAt(0);
            ViewBag.Modèle = locationInfo.ElementAt(1);
            ViewBag.NuméroVoiture = locationInfo.ElementAt(2);
            ViewBag.NombreJoursLocation = locationInfo.ElementAt(3);
            ViewBag.CodeSuccursaleRetour = locationInfo.ElementAt(4);
            ViewBag.NuméroPermisConduire = locationInfo.ElementAt(5);
            //    <label asp-for="CodeSuccursale">Code de la Succursale : </label>
            //    <label asp-for="Modèle">Modèle : </label>
            //    <label asp-for="NombreJoursLocation">Nombre de jours avant le retour : </label>
            //    <label asp-for="NuméroVoiture">Modèle :</label>
            //    <label>Code de la Succursale de retour :</label>

            return View();
        }

    }
}
