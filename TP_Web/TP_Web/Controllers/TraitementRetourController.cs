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


            if (location is null)
            {
                ModelState.AddModelError(nameof(RetourVoitureModèle.NuméroVoiture), "Il n'y a pas de locations existantes pour cette voiture");

                return View();
            }
            else
            {
                if (location.Voiture.Millage > p_voiture.NouveauMillage)
                    ModelState.AddModelError(nameof(RetourVoitureModèle.NouveauMillage), "La voiture à un millage inférieur au moment où elle a été loué");

                if (location.Client.NuméroPermisConduire != p_voiture.NuméroPermisConduire && dépôt.Locations.Any(v => v.Voiture.NuméroVoiture == p_voiture.NuméroVoiture))
                    ModelState.AddModelError(nameof(RetourVoitureModèle.NuméroPermisConduire), "La voiture n'est pas actuellement louée au client désigné");

                if (!dépôt.Voitures.Any(v => v.NuméroVoiture == p_voiture.NuméroVoiture))
                    ModelState.AddModelError(nameof(RetourVoitureModèle.NuméroVoiture), "Aucune voiture trouvé associé à ce numéro");

                if (!dépôt.Succursales.Any(v => v.SuccursaleId == p_voiture.SuccursaleDeRetour))
                    ModelState.AddModelError(nameof(RetourVoitureModèle.SuccursaleDeRetour), "Aucune succursale trouvé à ce numéro");
            }



            if (ModelState.IsValid)
            {
                List<string> TempDataVoiture = new List<string>();
                TempDataVoiture.Add(p_voiture.NuméroVoiture.ToString());
                TempDataVoiture.Add(p_voiture.NouveauMillage.ToString());
                TempDataVoiture.Add(p_voiture.NuméroPermisConduire);
                TempDataVoiture.Add(p_voiture.SuccursaleDeRetour.ToString());

                TempData["VoitureInfo"] = TempDataVoiture;

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
            TempDataVoiture.Add(location.Client.NuméroPermisConduire);
            TempDataVoiture.Add(voitureNumero.ToString());
            TempDataVoiture.Add(ViewBag.NomClient);
            TempDataVoiture.Add(ViewBag.PrénomClient);

            TempData["ClientData"] = TempDataVoiture;



            dépôt.RetourVoiture(location.Voiture.NuméroVoiture, succursaleRetourné, location.LocationId);

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

        public ViewResult RapportAccident()
        {
            ViewBag.Noms = "Arnaud Labrecque & Kevin Pugliese";

            return View();
        }

        [HttpPost]
        public IActionResult RapportAccident(DossierAccident da)
        {
            ViewBag.Noms = "Arnaud Labrecque & Kevin Pugliese";

            IEnumerable<string> client = (IEnumerable<string>)TempData["ClientData"];
            var clientFauteux = client.ElementAt(0);
            var voiture = client.ElementAt(1);

            ViewBag.NomClient = client.ElementAt(2);
            ViewBag.PrénomClient = client.ElementAt(3);
            ViewBag.NumeroPermis = clientFauteux;
            ViewBag.NumVoiture = voiture;

            DossierAccident DossierRentré = new DossierAccident
            {
                RapportAccident = da.RapportAccident,
                DossierFermé = false,
                Client = dépôt.Clients.First(c => c.NuméroPermisConduire == clientFauteux),
                Voiture = dépôt.Voitures.First(v => v.NuméroVoiture == long.Parse(voiture))

            };

            dépôt.AjouterDossier(DossierRentré);


            return Redirect("Home/Index");
        }
    }
}
