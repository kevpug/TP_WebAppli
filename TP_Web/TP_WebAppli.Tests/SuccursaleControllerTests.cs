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
    public sealed class SuccursaleControllerTests : ReadMe
    {
        [Fact]
        public void ExceptionCodeDéjàUtilisé()
        {

            //Arrange, mettre en place les conditions du test
            Mock<IDépôt> mock = new Mock<IDépôt>();
            mock.Setup(a => a.Succursales).Returns((new Succursale[] {
                new Succursale {
                    SuccursaleId = 1, CodeSuccursale = 1, NomProvince = "QC",
                    CodePostal = "J3A3G3", NomRue = "Bélanger", NomVille="Boubou",
                    NuméroCivique = 10, NuméroTéléphone="4501231234", Voitures = new List<Voiture>()
                }
            }).AsQueryable<Succursale>());
            SuccursaleController SC = new SuccursaleController(mock.Object);

            Succursale fun = new Succursale
            {
                SuccursaleId = 2,
                CodeSuccursale = 1, // Exception CODE DÉJÀ UTILISÉ
                NomProvince = "QC",
                CodePostal = "J3A3G4",
                NomRue = "Bibouque",
                NomVille = "Blablaland",
                NuméroCivique = 20,
                NuméroTéléphone = "4501235678",
                Voitures = new List<Voiture>()
            };

            //Act, faire le test
            SC.AjouterSuccursale(fun);

            //Assert, vérifier le résultat du test
            Assert.True(SC.ModelState.ErrorCount == 1);
        }

        [Fact]
        public void ExceptionCodeNégatif()
        {

            //Arrange, mettre en place les conditions du test
            Mock<IDépôt> mock = new Mock<IDépôt>();
            mock.Setup(a => a.Succursales).Returns((new Succursale[] {
                new Succursale {
                    SuccursaleId = 1, CodeSuccursale = 1, NomProvince = "QC",
                    CodePostal = "J3A3G3", NomRue = "Bélanger", NomVille="Boubou",
                    NuméroCivique = 10, NuméroTéléphone="4501231234", Voitures = new List<Voiture>()
                }
            }).AsQueryable<Succursale>());
            SuccursaleController SC = new SuccursaleController(mock.Object);

            Succursale fun = new Succursale
            {
                SuccursaleId = 2,
                CodeSuccursale = -2, //Code négatif
                NomProvince = "QC",
                CodePostal = "J3A3G4",
                NomRue = "Bibouque",
                NomVille = "Blablaland",
                NuméroCivique = 20,
                NuméroTéléphone = "4501235678",
                Voitures = new List<Voiture>()
            };

            //Act, faire le test
            SC.AjouterSuccursale(fun);

            //Assert, vérifier le résultat du test
            Assert.True(SC.ModelState.ErrorCount == 1);
        }

        [Fact]
        public void ExceptionMêmeRueEtCodePostal()
        {

            //Arrange, mettre en place les conditions du test
            Mock<IDépôt> mock = new Mock<IDépôt>();
            mock.Setup(a => a.Succursales).Returns((new Succursale[] {
                new Succursale {
                    SuccursaleId = 1, CodeSuccursale = 1, NomProvince = "QC",
                    CodePostal = "J3A3G3", NomRue = "Bélanger", NomVille="Boubou",
                    NuméroCivique = 10, NuméroTéléphone="4501231234", Voitures = new List<Voiture>()
                }
            }).AsQueryable<Succursale>());
            SuccursaleController SC = new SuccursaleController(mock.Object);

            Succursale fun = new Succursale
            {
                SuccursaleId = 2,
                CodeSuccursale = 2, 
                NomProvince = "QC",
                CodePostal = "J3A3G3", //Même code postal que succursale 1
                NomRue = "Bélanger",  //Même nom de rue que succursale 1
                NomVille = "Boubou",
                NuméroCivique = 20,
                NuméroTéléphone = "4501235678",
                Voitures = new List<Voiture>()
            };

            //Act, faire le test
            SC.AjouterSuccursale(fun);

            //Assert, vérifier le résultat du test
            Assert.True(SC.ModelState.ErrorCount == 2);
        }

        [Fact]
        public void ExceptionAutreVilleMêmeCodePostal()
        {
            //Arrange, mettre en place les conditions du test
            Mock<IDépôt> mock = new Mock<IDépôt>();
            mock.Setup(a => a.Succursales).Returns((new Succursale[] {
                new Succursale {
                    SuccursaleId = 1, CodeSuccursale = 1, NomProvince = "QC",
                    CodePostal = "J3A3G3", NomRue = "Bélanger", NomVille="Boubou",
                    NuméroCivique = 10, NuméroTéléphone="4501231234", Voitures = new List<Voiture>()
                }
            }).AsQueryable<Succursale>());
            SuccursaleController SC = new SuccursaleController(mock.Object);

            Succursale fun = new Succursale
            {
                SuccursaleId = 2,
                CodeSuccursale = 2,
                NomProvince = "QC", 
                CodePostal = "J3A3G3", //Même code postal que succursale 1
                NomRue = "SKLA",  
                NomVille = "Blablaland", //Différent nom de ville
                NuméroCivique = 20,
                NuméroTéléphone = "4501235678",
                Voitures = new List<Voiture>()
            };

            //Act, faire le test
            SC.AjouterSuccursale(fun);

            //Assert, vérifier le résultat du test
            Assert.True(SC.ModelState.ErrorCount == 2);
        }
        [Fact]
        public void ExceptionAutreProvinceMêmeCodePostal()
        {
            //Arrange, mettre en place les conditions du test
            Mock<IDépôt> mock = new Mock<IDépôt>();
            mock.Setup(a => a.Succursales).Returns((new Succursale[] {
                new Succursale {
                    SuccursaleId = 1, CodeSuccursale = 1, NomProvince = "QC",
                    CodePostal = "J3A3G3", NomRue = "Bélanger", NomVille="Boubou",
                    NuméroCivique = 10, NuméroTéléphone="4501231234", Voitures = new List<Voiture>()
                }
            }).AsQueryable<Succursale>());
            SuccursaleController SC = new SuccursaleController(mock.Object);

            Succursale fun = new Succursale
            {
                SuccursaleId = 2,
                CodeSuccursale = 2,
                NomProvince = "ABOUK", //Différent nom de province
                CodePostal = "J3A3G3", //Même code postal que succursale 1
                NomRue = "SKLA",
                NomVille = "Boubou", 
                NuméroCivique = 20,
                NuméroTéléphone = "4501235678",
                Voitures = new List<Voiture>()
            };

            //Act, faire le test
            SC.AjouterSuccursale(fun);

            //Assert, vérifier le résultat du test
            Assert.True(SC.ModelState.ErrorCount == 2);
        }

        [Fact]
        public void ExceptionCodePostalInvalide()
        {
            //Arrange, mettre en place les conditions du test
            Mock<IDépôt> mock = new Mock<IDépôt>();
            mock.Setup(a => a.Succursales).Returns((new Succursale[] {
                new Succursale {
                    SuccursaleId = 1, CodeSuccursale = 1, NomProvince = "QC",
                    CodePostal = "J3A3G3", NomRue = "Bélanger", NomVille="Boubou",
                    NuméroCivique = 10, NuméroTéléphone="4501231234", Voitures = new List<Voiture>()
                }
            }).AsQueryable<Succursale>());
            SuccursaleController SC = new SuccursaleController(mock.Object);

            Succursale fun = new Succursale
            {
                SuccursaleId = 2,
                CodeSuccursale = 2,
                NomProvince = "ABOUK",
                CodePostal = "J3Ea", //Code postal invalide
                NomRue = "SKLA",
                NomVille = "Boubou",
                NuméroCivique = 20,
                NuméroTéléphone = "4501235678",
                Voitures = new List<Voiture>()
            };

            //Act, faire le test
            SC.AjouterSuccursale(fun);

            //Assert, vérifier le résultat du test
            Assert.True(SC.ModelState.ErrorCount == 1);
        }



        [Fact]
        public void ExceptionCodeCiviqueNégatif()
        {
            //Arrange, mettre en place les conditions du test
            Mock<IDépôt> mock = new Mock<IDépôt>();
            mock.Setup(a => a.Succursales).Returns((new Succursale[] {
                new Succursale {
                    SuccursaleId = 1, CodeSuccursale = 1, NomProvince = "QC",
                    CodePostal = "J3A3G3", NomRue = "Bélanger", NomVille="Boubou",
                    NuméroCivique = 10, NuméroTéléphone="4501231234", Voitures = new List<Voiture>()
                }
            }).AsQueryable<Succursale>());
            SuccursaleController SC = new SuccursaleController(mock.Object);

            Succursale fun = new Succursale
            {
                SuccursaleId = 2,
                CodeSuccursale = 2,
                NomProvince = "ABOUK",
                CodePostal = "J3A3G4",
                NomRue = "SKLA",
                NomVille = "Val",
                NuméroCivique = -20, //Numéro civique négatif
                NuméroTéléphone = "4501235678",
                Voitures = new List<Voiture>()
            };

            //Act, faire le test
            SC.AjouterSuccursale(fun);

            //Assert, vérifier le résultat du test
            Assert.True(SC.ModelState.ErrorCount == 1);
        }

        [Fact]
        public void ExceptionTéléphoneInvalide()
        {
            //Arrange, mettre en place les conditions du test
            Mock<IDépôt> mock = new Mock<IDépôt>();
            mock.Setup(a => a.Succursales).Returns((new Succursale[] {
                new Succursale {
                    SuccursaleId = 1, CodeSuccursale = 1, NomProvince = "QC",
                    CodePostal = "J3A3G3", NomRue = "Bélanger", NomVille="Boubou",
                    NuméroCivique = 10, NuméroTéléphone="4501231234", Voitures = new List<Voiture>()
                }
            }).AsQueryable<Succursale>());
            SuccursaleController SC = new SuccursaleController(mock.Object);

            Succursale fun = new Succursale
            {
                SuccursaleId = 2,
                CodeSuccursale = 2,
                NomProvince = "ABOUK",
                CodePostal = "J3A3G4",
                NomRue = "SKLA",
                NomVille = "Val",
                NuméroCivique = 20,
                NuméroTéléphone = "45012356789239292", //Numéro de téléphone invalide
                Voitures = new List<Voiture>()
            };

            //Act, faire le test
            SC.AjouterSuccursale(fun);

            //Assert, vérifier le résultat du test
            Assert.True(SC.ModelState.ErrorCount == 1);
        }

    }
}
