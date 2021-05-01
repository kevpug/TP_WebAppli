using TP_Web.Controllers;
using TP_Web;
using Xunit;
using TP_Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace TP01_WebAppli.Tests
{
    public sealed class UtilisateurControllerTests : ReadMe
    {


        //DbContextOptions<ContexteAutoLoco> p_optionsAutoLoco = new DbContextOptionsBuilder<ContexteAutoLoco>()
        //    .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=AutoLoco;MultipleActiveResultSets=True")
        //    .Options;
        //DbContextOptions<ContexteIdentité> p_optionsIdentité = new DbContextOptionsBuilder<ContexteIdentité>()
        //    .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=IdentityUtilisateur;Trusted_Connection=True; MultipleActiveResultSets=True")
        //    .Options;

        //var contextAutoLoco = new ContexteAutoLoco(p_optionsAutoLoco);
        //var contexteIdentité = new ContexteIdentité(p_optionsIdentité);
        //IDépôt dépôt = new DépôtEF(contextAutoLoco, contexteIdentité);


        [Fact]
        public void ExceptionCodeDéjàUtilisé() {

            //Arrange, mettre en place les conditions du test
            Mock<IDépôt> mock = new Mock<IDépôt>();
            mock.Setup(a => a.Succursales).Returns((new Succursale[] {
                new Succursale {
                    SuccursaleId = 1, CodeSuccursale = 1, NomProvince = "QC",
                    CodePostal = "J3A3G3E", NomRue = "Bélanger", NomVille="Boubou",
                    NuméroCivique = 10, NuméroTéléphone="4501231234", Voitures = new List<Voiture>()
                }
            }).AsQueryable<Succursale>());
            SuccursaleController SC = new SuccursaleController(mock.Object);

            Succursale fun = new Succursale
            {
                SuccursaleId = 2,
                CodeSuccursale = 1, // Exception CODE DÉJÀ UTILISÉ
                NomProvince = "QC",
                CodePostal = "J3A3G4E",
                NomRue = "Bibouque",
                NomVille = "Blablaland",
                NuméroCivique = 20,
                NuméroTéléphone = "4501235678",
                Voitures = new List<Voiture>()
            };

            //Act, faire le test
            SC.AjouterSuccursale(fun);

            //Assert, vérifier le résultat du test
            Assert.True(SC.ModelState.ErrorCount > 0);
        }

    }
}
