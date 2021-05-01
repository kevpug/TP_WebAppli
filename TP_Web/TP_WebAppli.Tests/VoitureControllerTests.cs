using Moq;
using System.Collections.Generic;
using System.Linq;
using TP_Web;
using TP_Web.Controllers;
using TP_Web.Models;
using Xunit;

namespace TP_WebAppli.Tests
{
    public sealed class VoitureControllerTests : ReadMe
    {

        [Fact]
        public void NuméroDeVoitureUtilisé()
        {

            //Arrange, mettre en place les conditions du test
            Mock<IDépôt> mock = new Mock<IDépôt>();

            mock.Setup(a => a.Succursales).Returns((new Succursale[] {
                new Succursale {
                    SuccursaleId = 1, CodeSuccursale = 1, NomProvince = "QC",
                    CodePostal = "J3A3G3E", NomRue = "Bélanger", NomVille="Boubou",
                    NuméroCivique = 10, NuméroTéléphone="4501231234", Voitures = new List<Voiture>()
                }
            }).AsQueryable<Succursale>());

            mock.Setup(a => a.Voitures).Returns((new Voiture[] {
                new Voiture {
                    VoitureId=1,NuméroVoiture = 1, Modèle = "QC",
                    Groupe = Voiture.GroupeVoiture.Compact, Millage = 30000,
                    Année = 1999, Succursale= mock.Object.Succursales.FirstOrDefault(), EstDisponible = true
                }
            }).AsQueryable<Voiture>());


            CréerVoitureModèle CVM = new CréerVoitureModèle
            {
                NuméroVoiture = 1,
                Année = 2000,
                Groupe = Voiture.GroupeVoiture.Compact,
                Millage = 300000,
                Modèle = "Poche",
                Succursale = 1
            };

            VoitureController VC = new VoitureController(mock.Object);


            //Act, faire le test
            VC.AjouterVoiture(CVM);

            //Assert, vérifier le résultat du test
            Assert.True(VC.ModelState.ErrorCount == 1);
        }

        [Fact]
        public void AutreGroupeModèle()
        {

            //Arrange, mettre en place les conditions du test
            Mock<IDépôt> mock = new Mock<IDépôt>();

            mock.Setup(a => a.Succursales).Returns((new Succursale[] {
                new Succursale {
                    SuccursaleId = 1, CodeSuccursale = 1, NomProvince = "QC",
                    CodePostal = "J3A3G3E", NomRue = "Bélanger", NomVille="Boubou",
                    NuméroCivique = 10, NuméroTéléphone="4501231234", Voitures = new List<Voiture>()
                }
            }).AsQueryable<Succursale>());

            mock.Setup(a => a.Voitures).Returns((new Voiture[] {
                new Voiture {
                    VoitureId=1,NuméroVoiture = 1, Modèle = "Poche",
                    Groupe = Voiture.GroupeVoiture.Compact, Millage = 30000,
                    Année = 1999, Succursale= mock.Object.Succursales.FirstOrDefault(), EstDisponible = true
                }
            }).AsQueryable<Voiture>());


            CréerVoitureModèle CVM = new CréerVoitureModèle
            {
                NuméroVoiture = 2,
                Année = 2000,
                Groupe = Voiture.GroupeVoiture.Sedan,
                Millage = 300000,
                Modèle = "Poche",
                Succursale = 1
            };

            VoitureController VC = new VoitureController(mock.Object);


            //Act, faire le test
            VC.AjouterVoiture(CVM);

            //Assert, vérifier le résultat du test
            Assert.True(VC.ModelState.ErrorCount == 1);
        }

        [Fact]
        public void AnnéeInvalide()
        {

            //Arrange, mettre en place les conditions du test
            Mock<IDépôt> mock = new Mock<IDépôt>();

            mock.Setup(a => a.Succursales).Returns((new Succursale[] {
                new Succursale {
                    SuccursaleId = 1, CodeSuccursale = 1, NomProvince = "QC",
                    CodePostal = "J3A3G3E", NomRue = "Bélanger", NomVille="Boubou",
                    NuméroCivique = 10, NuméroTéléphone="4501231234", Voitures = new List<Voiture>()
                }
            }).AsQueryable<Succursale>());

            CréerVoitureModèle CVM = new CréerVoitureModèle
            {
                NuméroVoiture = 2,
                Année = 2000000, // L'année dépasse la limite de 9999
                Groupe = Voiture.GroupeVoiture.Sedan,
                Millage = 300000,
                Modèle = "Poche",
                Succursale = 1
            };

            VoitureController VC = new VoitureController(mock.Object);


            //Act, faire le test
            VC.AjouterVoiture(CVM);

            //Assert, vérifier le résultat du test
            Assert.True(VC.ModelState.ErrorCount == 1);
        }

        [Fact]
        public void MillageNégatif()
        {

            //Arrange, mettre en place les conditions du test
            Mock<IDépôt> mock = new Mock<IDépôt>();

            mock.Setup(a => a.Succursales).Returns((new Succursale[] {
                new Succursale {
                    SuccursaleId = 1, CodeSuccursale = 1, NomProvince = "QC",
                    CodePostal = "J3A3G3E", NomRue = "Bélanger", NomVille="Boubou",
                    NuméroCivique = 10, NuméroTéléphone="4501231234", Voitures = new List<Voiture>()
                }
            }).AsQueryable<Succursale>());


            CréerVoitureModèle CVM = new CréerVoitureModèle
            {
                NuméroVoiture = 2,
                Année = 2000,
                Groupe = Voiture.GroupeVoiture.Sedan,
                Millage = -300000, // Millage négtif ici
                Modèle = "Poche",
                Succursale = 1
            };

            VoitureController VC = new VoitureController(mock.Object);


            //Act, faire le test
            VC.AjouterVoiture(CVM);

            //Assert, vérifier le résultat du test
            Assert.True(VC.ModelState.ErrorCount == 1);
        }

        [Fact]
        public void CodeNégatif()
        {

            //Arrange, mettre en place les conditions du test
            Mock<IDépôt> mock = new Mock<IDépôt>();

            mock.Setup(a => a.Succursales).Returns((new Succursale[] {
                new Succursale {
                    SuccursaleId = 1, CodeSuccursale = 1, NomProvince = "QC",
                    CodePostal = "J3A3G3E", NomRue = "Bélanger", NomVille="Boubou",
                    NuméroCivique = 10, NuméroTéléphone="4501231234", Voitures = new List<Voiture>()
                }
            }).AsQueryable<Succursale>());


            CréerVoitureModèle CVM = new CréerVoitureModèle
            {
                NuméroVoiture = -2, // Code négatif ici
                Année = 2000,
                Groupe = Voiture.GroupeVoiture.Sedan,
                Millage = 300000,
                Modèle = "Poche",
                Succursale = 1
            };

            VoitureController VC = new VoitureController(mock.Object);


            //Act, faire le test
            VC.AjouterVoiture(CVM);

            //Assert, vérifier le résultat du test
            Assert.True(VC.ModelState.ErrorCount == 1);
        }

        [Fact]
        public void SuccursaleInexistante()
        {

            //Arrange, mettre en place les conditions du test
            Mock<IDépôt> mock = new Mock<IDépôt>();

            mock.Setup(a => a.Succursales).Returns((new Succursale[] {
                new Succursale {
                    SuccursaleId = 1, CodeSuccursale = 1, NomProvince = "QC",
                    CodePostal = "J3A3G3E", NomRue = "Bélanger", NomVille="Boubou",
                    NuméroCivique = 10, NuméroTéléphone="4501231234", Voitures = new List<Voiture>()
                }
            }).AsQueryable<Succursale>());

            CréerVoitureModèle CVM = new CréerVoitureModèle
            {
                NuméroVoiture = 2,
                Année = 2000,
                Groupe = Voiture.GroupeVoiture.Sedan,
                Millage = 300000,
                Modèle = "Poche",
                Succursale = 20 // Succursale inexistante
            };

            VoitureController VC = new VoitureController(mock.Object);


            //Act, faire le test
            VC.AjouterVoiture(CVM);

            //Assert, vérifier le résultat du test
            Assert.True(VC.ModelState.ErrorCount == 1);
        }
    }
}
