using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP_Web;
using TP_Web.Controllers;
using TP_Web.Models;
using Xunit;

namespace TP_WebAppli.Tests
{
    public class LocationControllerTests : ReadMe
    {
        [Fact]
        public void AjoutLocationVoiture()
        {
            Mock<IDépôt> mock = new Mock<IDépôt>();
            mock.Setup(m => m.Succursales).Returns((new Succursale[] {
                new Succursale
                {
                    SuccursaleId = 1,
                    CodePostal = "J3H3J4",
                    CodeSuccursale = 1,
                    NomProvince = "Blip",
                    NomRue = "Lap",
                    NomVille = "Waste",
                    NuméroCivique = 1,
                    NuméroTéléphone = "4504504500"
                }
            }).AsQueryable<Succursale>());

            mock.Setup(m => m.Voitures).Returns((new Voiture[] {
                new Voiture
                {
                    VoitureId = 1,
                    EstDisponible = true,
                    Année = 2000,
                    Groupe = Voiture.GroupeVoiture.Luxe,
                    Millage = 20000,
                    NuméroVoiture = 1,
                    Succursale = mock.Object.Succursales.FirstOrDefault(),
                    Modèle = "Baraquaq"
                }
            }).AsQueryable<Voiture>());

            mock.Setup(m => m.Clients).Returns((new Client[] {
                new Client
                {
                    ClientId = 1,
                    Nom = "Pla",
                    Prénom = "Bli",
                    NuméroPermisConduire = "A2",
                    NuméroTéléphone = "4504504501"
                }
            }).AsQueryable<Client>());
            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            //tempData[""]

            //var produit = new Produit
            //{
            //    Nom = "Laitue",
            //    Description = "Verte et cool",
            //    Prix = 3,
            //    Catégorie = "Légume"
            //};
            //List<string> TempDataModele = new List<string>();
            //TempDataModele.Add(CodeSuccursale);
            //TempDataModele.Add(Modèle);
            //TempDataModele.Add(NuméroVoiture);
            //TempDataModele.Add(NombreJoursLocation);
            //TempDataModele.Add(CodeSuccursaleRetour);
            //TempDataModele.Add(NuméroPermisConduire);
            //TempData["LocationInfo"] = TempDataModele;

            LocationController Lc = new LocationController(mock.Object) { TempData = tempData };
            LocationVoitureModèle lvm = new LocationVoitureModèle()
            {
                CodeSuccursale = 1,
                CodeSuccursaleRetour = 1,
            };
            Lc.VoituresDispo();

            

            //Assert, vérifier le résultat du test
            //Assert.True(Pc.ModelState.IsValid);
        }
    }
}
