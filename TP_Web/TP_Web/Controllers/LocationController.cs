﻿using Microsoft.AspNetCore.Authorization;
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
            if (p_lvm.Modèle is object)
                if (!dépôt.Voitures.Any(s => s.Modèle == p_lvm.Modèle))
                    ModelState.AddModelError(nameof(LocationVoitureModèle.Modèle), "Ce modèle de voiture n'existe pas!");
                else
                    ModelState.AddModelError(nameof(LocationVoitureModèle.Modèle), "Veuillez entrer un modèle.");

            if (p_lvm.CodeSuccursale is object)
                if (!dépôt.Succursales.Any(s => s.CodeSuccursale == p_lvm.CodeSuccursale))
                    ModelState.AddModelError(nameof(LocationVoitureModèle.CodeSuccursale), "Ce code de succursale n'existe pas!");
                else
                    ModelState.AddModelError(nameof(LocationVoitureModèle.CodeSuccursale), "Veuillez entrer un code de succursale.");

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

            if (ModelState.IsValid)
            {
                return RedirectToAction("VoituresDispo");
            }
            return View(p_lvm);
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

                try
                {
                    Voiture.GroupeVoiture grpVoiture = (Voiture.GroupeVoiture)dépôt.Voitures.First(v => v.Modèle == Modèle).Groupe;
                    ViewBag.ListeNumeroVoitures = dépôt.Voitures.Where(s => s.Groupe == grpVoiture && s.Succursale.CodeSuccursale.ToString() == CodeSuccursale && s.EstDisponible)
                    .Select(v => v.NuméroVoiture);
                    if (ViewBag.ListeNumeroVoitures.Count > 0)
                        ModelState.AddModelError(nameof(LocationVoitureModèle.NuméroVoiture), $"Il n'y a pas de voiture disponible du modèle {Modèle}... affichage des autres voitures du groupe {grpVoiture}.");
                }
                catch
                {
                    ModelState.AddModelError(nameof(LocationVoitureModèle.NuméroVoiture), $"Aucune voiture disponible.");
                }
            }
            return View();
        }


        [HttpPost]
        [Authorize(Roles = "Gerant, Commis")]
        public IActionResult VoituresDispo(LocationVoitureModèle p_lvm)
        {
            if (p_lvm.NuméroVoiture is object)
                if (!dépôt.Voitures.Any(s => s.NuméroVoiture == p_lvm.NuméroVoiture))
                    ModelState.AddModelError(nameof(LocationVoitureModèle.NuméroVoiture), "Aucune voiture existe avec ce numéro!");

            if (p_lvm.NombreJoursLocation <= 0)
                ModelState.AddModelError(nameof(LocationVoitureModèle.NombreJoursLocation), "Veuillez entrer un nombre de jour positif.");

            if (!dépôt.Succursales.Any(s => s.CodeSuccursale == p_lvm.CodeSuccursaleRetour))
            {
                ModelState.AddModelError(nameof(LocationVoitureModèle.CodeSuccursaleRetour), "Ce code de succursale n'existe pas!");
            }

            if (dépôt.Locations.Any(l => l.DateDeLocation.Date.ToShortDateString() == DateTime.Now.Date.ToShortDateString()))
                ModelState.AddModelError(nameof(LocationVoitureModèle.Modèle), "Ce véhicule a déjà été loué aujourd'hui.");

            if (dépôt.DossierAccidents.Any(l => l.Client.NuméroPermisConduire == p_lvm.NuméroPermisConduire && !l.DossierFermé))
                ModelState.AddModelError(nameof(LocationVoitureModèle.NuméroPermisConduire), "Ce client a un dossier accident toujours ouvert!");

            if (dépôt.Locations.Any(l => l.Client.NuméroPermisConduire == p_lvm.NuméroPermisConduire && !l.Voiture.EstDisponible))
                ModelState.AddModelError(nameof(LocationVoitureModèle.NuméroPermisConduire), "Ce client a déjà une location de voiture en cours!");


            IEnumerable<string> locationInfo = (IEnumerable<string>)TempData["LocationInfo"];
            if (locationInfo is null)
                return Redirect("../Location/ChoisirModele"); //Éviter le crash...
            string CodeSuccursale = locationInfo.ElementAt(0);
            ViewBag.CodeSuccursale = CodeSuccursale;
            string Modèle = locationInfo.ElementAt(1);
            ViewBag.Modèle = Modèle;
            List<string> TempDataModele = new List<string>();
            TempDataModele.Add(locationInfo.ElementAt(0));
            TempDataModele.Add(locationInfo.ElementAt(1));
            TempDataModele.Add(p_lvm.NuméroVoiture.ToString());
            TempDataModele.Add(p_lvm.NombreJoursLocation.ToString());
            TempDataModele.Add(p_lvm.CodeSuccursaleRetour.ToString());
            TempDataModele.Add(p_lvm.NuméroPermisConduire.ToString());
            TempData["LocationInfo"] = TempDataModele;


            try
            {
                ViewBag.ListeSuccursales = dépôt.Succursales;
                ViewBag.ListeNumeroVoitures = dépôt.Voitures.Where(s => s.Modèle == Modèle && s.Succursale.CodeSuccursale.ToString() == CodeSuccursale && s.EstDisponible)
                .Select(v => v.NuméroVoiture);
            }
            catch
            {

                try
                {
                    Voiture.GroupeVoiture grpVoiture = (Voiture.GroupeVoiture)dépôt.Voitures.First(v => v.Modèle == Modèle).Groupe;
                    ViewBag.ListeNumeroVoitures = dépôt.Voitures.Where(s => s.Groupe == grpVoiture && s.Succursale.CodeSuccursale.ToString() == CodeSuccursale && s.EstDisponible)
                    .Select(v => v.NuméroVoiture);
                    if (ViewBag.ListeNumeroVoitures.Count > 0)
                        ModelState.AddModelError(nameof(LocationVoitureModèle.NuméroVoiture), $"Il n'y a pas de voiture disponible du modèle {Modèle}... affichage des autres voitures du groupe {grpVoiture}.");
                }
                catch
                {
                    ModelState.AddModelError(nameof(LocationVoitureModèle.NuméroVoiture), $"Aucune voiture disponible.");
                }
            }


            bool bClientExiste = dépôt.Clients.Any(c => c.NuméroPermisConduire == p_lvm.NuméroPermisConduire);
            if (ModelState.IsValid && !bClientExiste)
                return RedirectToAction("CréationClientLocation");
            else if (ModelState.IsValid && bClientExiste)
            {
                dépôt.AjouterLocation(new Location()
                {
                    SuccursaleDeRetour = dépôt.Succursales.FirstOrDefault(s => s.CodeSuccursale == p_lvm.CodeSuccursaleRetour),
                    Client = dépôt.Clients.FirstOrDefault(c => c.NuméroPermisConduire == p_lvm.NuméroPermisConduire),
                    DateDeLocation = DateTime.Now,
                    NombreJoursLocation = p_lvm.NombreJoursLocation,
                    Voiture = dépôt.Voitures.FirstOrDefault(v => v.NuméroVoiture == p_lvm.NuméroVoiture)
                }); ;
                return Redirect("../Home/Index");
            }
            else
                return View(p_lvm);
        }

        [HttpGet]
        [Authorize(Roles = "Gerant, Commis")]
        public IActionResult CréationClientLocation()
        {
            IEnumerable<string> locationInfo = (IEnumerable<string>)TempData["LocationInfo"];
            if (locationInfo is null)
                return Redirect("../Location/ChoisirModele"); //Éviter le crash...
            string CodeSuccursale = locationInfo.ElementAt(0);
            ViewBag.CodeSuccursale = CodeSuccursale;
            string Modèle = locationInfo.ElementAt(1);
            ViewBag.Modèle = Modèle;
            string NuméroVoiture = locationInfo.ElementAt(2);
            ViewBag.NuméroVoiture = NuméroVoiture;
            string NombreJoursLocation = locationInfo.ElementAt(3);
            ViewBag.NombreJoursLocation = NombreJoursLocation;
            string CodeSuccursaleRetour = locationInfo.ElementAt(4);
            ViewBag.CodeSuccursaleRetour = CodeSuccursaleRetour;
            string NuméroPermisConduire = locationInfo.ElementAt(5);
            ViewBag.NuméroPermisConduire = NuméroPermisConduire;

            List<string> TempDataModele = new List<string>();
            TempDataModele.Add(CodeSuccursale);
            TempDataModele.Add(Modèle);
            TempDataModele.Add(NuméroVoiture);
            TempDataModele.Add(NombreJoursLocation);
            TempDataModele.Add(CodeSuccursaleRetour);
            TempDataModele.Add(NuméroPermisConduire);
            TempData["LocationInfo"] = TempDataModele;


            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Gerant, Commis")]
        public IActionResult CréationClientLocation(LocationVoitureModèle p_lvm)
        {
            //TODO: Faire validation sur les champs restants iciIIIIIIIIIIIIIII

            IEnumerable<string> locationInfo = (IEnumerable<string>)TempData["LocationInfo"];
            if (locationInfo is null)
                return Redirect("../Location/ChoisirModele"); //Éviter le crash...
            string CodeSuccursale = locationInfo.ElementAt(0);
            ViewBag.CodeSuccursale = CodeSuccursale;
            string Modèle = locationInfo.ElementAt(1);
            ViewBag.Modèle = Modèle;
            string NuméroVoiture = locationInfo.ElementAt(2);
            ViewBag.NuméroVoiture = NuméroVoiture;
            string NombreJoursLocation = locationInfo.ElementAt(3);
            ViewBag.NombreJoursLocation = NombreJoursLocation;
            string CodeSuccursaleRetour = locationInfo.ElementAt(4);
            ViewBag.CodeSuccursaleRetour = CodeSuccursaleRetour;
            string NuméroPermisConduire = locationInfo.ElementAt(5);
            ViewBag.NuméroPermisConduire = NuméroPermisConduire;

            List<string> TempDataModele = new List<string>();
            TempDataModele.Add(CodeSuccursale);
            TempDataModele.Add(Modèle);
            TempDataModele.Add(NuméroVoiture);
            TempDataModele.Add(NombreJoursLocation);
            TempDataModele.Add(CodeSuccursaleRetour);
            TempDataModele.Add(NuméroPermisConduire);
            TempData["LocationInfo"] = TempDataModele;

            if (ModelState.IsValid)
            {
                //Faire la création d'un client avec les champs dans p_lvm
                //Faire une location avec les champs plus haut pogné du tempdata
                return Redirect("../Home/Index");
            }
            return View(p_lvm);
        }
    }
}
