using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TP_Web.Models;

namespace TP_Web.Controllers
{
    public class TraitementRetourController : Controller
    {
        private IDépôt dépôt;

        public TraitementRetourController(IDépôt p_dépôt)
        {
            dépôt = p_dépôt;
        }

        [HttpGet]
        [Authorize(Roles = "Gerant, Commis")]
        public ViewResult RetournerVoiture()
        {
            ViewBag.Noms = "Arnaud Labrecque & Kevin Pugliese";
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Gerant, Commis")]
        public IActionResult RetournerVoiture(RetourVoitureModèle p_voiture)
        {
            ViewBag.Noms = "Arnaud Labrecque & Kevin Pugliese";

            var location = dépôt.Locations.Where(l => l.Voiture.NuméroVoiture == p_voiture.NuméroVoiture).FirstOrDefault();


            if (location.Voiture.Millage > p_voiture.NouveauMillage)
                ModelState.AddModelError(nameof(RetourVoitureModèle.NouveauMillage), "La voiture à un millage inférieur au moment où elle a été loué");

            if (location.Client.NuméroPermisConduire != p_voiture.NuméroPermisConduire && dépôt.Locations.Any(v => v.Voiture.NuméroVoiture == p_voiture.NuméroVoiture))
                ModelState.AddModelError(nameof(RetourVoitureModèle.NuméroPermisConduire), "La voiture n'est pas actuellement louée au client désigné");

            if (!dépôt.Voitures.Any(v => v.NuméroVoiture == p_voiture.NuméroVoiture))
                ModelState.AddModelError(nameof(RetourVoitureModèle.NuméroVoiture), "Aucune voiture trouvé associé à ce numéro");

            if (!dépôt.Succursales.Any(v => v.SuccursaleId == p_voiture.SuccursaleDeRetour))
                ModelState.AddModelError(nameof(RetourVoitureModèle.SuccursaleDeRetour), "Aucune succursale trouvé à ce numéro");


            if (ModelState.IsValid)
            {
                List<string> TempDataVoiture = new List<string>();
                TempDataVoiture.Add(p_voiture.NuméroVoiture.ToString());
                TempDataVoiture.Add(p_voiture.NouveauMillage.ToString());
                TempDataVoiture.Add(p_voiture.NuméroPermisConduire);
                TempDataVoiture.Add(p_voiture.SuccursaleDeRetour.ToString());

                TempData["VoitureInfo"] = TempDataVoiture;

                dépôt.RetourVoiture(p_voiture.NuméroVoiture, p_voiture.SuccursaleDeRetour); // On peut faire le changement de contexte avant l'affichage, puisque qu'il n'y pas de post apres

                return RedirectToAction("FinaliserTraitement");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        [Authorize(Roles = "Gerant, Commis")]
        public ViewResult FinaliserTraitement()
        {

            ViewBag.Noms = "Arnaud Labrecque & Kevin Pugliese";
            IEnumerable<string> voiture = (IEnumerable<string>)TempData["VoitureInfo"];
            long voitureNumero = long.Parse(voiture.First()); // J'ai accès au numéro de la voiture avec ça
            long succursaleRetourné = long.Parse(voiture.ElementAt(3));

            var location = dépôt.Locations.Where(l => l.Voiture.NuméroVoiture == voitureNumero).FirstOrDefault();

            DateTime DateDeLocation = location.DateDeLocation;
            DateTime shouldArrive = location.DateDeLocation.AddDays(location.NombreJoursLocation);

            ViewBag.DateDeLocation = DateDeLocation.ToString();
            ViewBag.NbJourRetour = location.NombreJoursLocation;
            ViewBag.SuccursalePrevu = location.SuccursaleDeRetour.SuccursaleId;
            ViewBag.NumPermis = location.Client.NuméroPermisConduire;
            ViewBag.NomClient = location.Client.Nom;
            ViewBag.PrénomClient = location.Client.Prénom;
            ViewBag.TelClient = location.Client.NuméroTéléphone;
            ViewBag.AvertissementSuccursale = false;
            ViewBag.AvertissementDate = false;


            List<string> TempDataVoiture = new List<string>();
            TempDataVoiture.Add(voitureNumero.ToString());
            TempDataVoiture.Add(location.Client.NuméroPermisConduire);

            TempData["ClientData"] = TempDataVoiture;


            if (shouldArrive.Date != DateTime.Now.Date)
            {
                ViewBag.AvertissementDate = true;
            }

            if (succursaleRetourné != location.SuccursaleDeRetour.SuccursaleId)
            {
                ViewBag.AvertissementSuccursale = true;
            }

            return View();
        }

        [HttpPost]
        public IActionResult FinaliserTraitement(DossierAccident da)
        {




            return View();
        }
    }
}
