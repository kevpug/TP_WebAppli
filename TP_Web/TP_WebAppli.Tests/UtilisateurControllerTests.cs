using TP01_Web;
using TP01_Web.Controllers;
using TP01_Web.Models;
using Xunit;

namespace TP01_WebAppli.Tests
{
    public sealed class UtilisateurControllerTests : ReadMe
    {
        [Fact]
        public void ExceptionCodeIncorrect() {
            //Arrange, mettre en place les conditions du test
            IDépôt dépôt = new DépôtDéveloppement();
            UtilisateurController utillisateurController = new UtilisateurController(dépôt);

            Utilisateur utilisateur = new Utilisateur
            {
                NomUtilisateur = "Admin2", //Mauvais code utilisateur
                MotDePasse = "Inimda23",
                Rôle = Utilisateur.TypeUtilisateur.Administrateur
            };

            //Act, faire le test
            utillisateurController.Authentification(utilisateur);

            //Assert, vérifier le résultat du test
            Assert.True(utillisateurController.ModelState.ErrorCount > 0);
        }

        [Fact]
        public void ExceptionCodeExistant()
        {
            //Arrange, mettre en place les conditions du test
            IDépôt dépôt = new DépôtDéveloppement();
            UtilisateurController utillisateurController = new UtilisateurController(dépôt);

            Utilisateur utilisateur = new Utilisateur
            {
                NomUtilisateur = "AdminI", //Code déjà existant par notre admin
                MotDePasse = "Inimda23",
                Rôle = Utilisateur.TypeUtilisateur.Commis
            };

            //Act, faire le test
            utillisateurController.AjouterUtilisateur(utilisateur);

            //Assert, vérifier le résultat du test
            Assert.True(utillisateurController.ModelState.ErrorCount > 0);
        }

        [Fact]
        public void ExceptionMdpIncorrect()
        {
            //Arrange, mettre en place les conditions du test
            IDépôt dépôt = new DépôtDéveloppement();
            UtilisateurController utillisateurController = new UtilisateurController(dépôt);

            Utilisateur utilisateur = new Utilisateur
            {
                NomUtilisateur = "AdminI", 
                MotDePasse = "Insd1223", //Mot de passe incorrect.
                Rôle = Utilisateur.TypeUtilisateur.Commis
            };

            //Act, faire le test
            utillisateurController.Authentification(utilisateur);

            //Assert, vérifier le résultat du test
            Assert.True(utillisateurController.ModelState.ErrorCount > 0);
        }
    }
}
