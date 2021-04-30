using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text.RegularExpressions;
using TP_Web.Models;
using System.Threading.Tasks;


namespace TP_Web.Controllers
{
    public class UtilisateurController : Controller, ReadMe
    {

        private UserManager<IdentityUser> gUtilisateur;
        private SignInManager<IdentityUser> gEnregistrement;

        public UtilisateurController(UserManager<IdentityUser> p_gu,
        SignInManager<IdentityUser> p_ge)
        {
            gUtilisateur = p_gu;
            gEnregistrement = p_ge;
        }

        [AllowAnonymous]
        public IActionResult Authentification(string returnUrl)
        {
            ViewBag.Noms = "Arnaud Labrecque & Kevin Pugliese";
            ViewBag.returnUrl = returnUrl;
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Authentification(ModèleLogin p_login, string returnUrl)
        {
            ViewBag.Noms = "Arnaud Labrecque & Kevin Pugliese";
            //if (string.IsNullOrEmpty(p_utilisateur.NomUtilisateur))
            //    ModelState.AddModelError(nameof(Utilisateur.NomUtilisateur), "Entrez un nom d'utilisateur.");
            //if (string.IsNullOrEmpty(p_utilisateur.MotDePasse))
            //    ModelState.AddModelError(nameof(Utilisateur.MotDePasse), "Entrez un mot de passe.");
            //if (dépôt.Utilisateurs.Any(u => u.NomUtilisateur == p_utilisateur.NomUtilisateur))
            //{
            //    if (!dépôt.Utilisateurs.Any(u => u.NomUtilisateur == p_utilisateur.NomUtilisateur && u.MotDePasse == p_utilisateur.MotDePasse))
            //        ModelState.AddModelError(nameof(Utilisateur.MotDePasse), "Le mot de passe est incorrect.");
            //}
            //else
            //    ModelState.AddModelError(nameof(Utilisateur.NomUtilisateur), "Le nom d'utilisateur entré n'existe pas.");

            //if (ModelState.IsValid)
            //{
            //    DépôtDéveloppement.UtilisateurConnecté = true;
            //    return View("../Utilisateur/Index"); // Ici on voudrait peut-être se connecter à l'index des utilisateurs pour voir Les Users Identity
            //}
            //else
            //    return View();
            if (ModelState.IsValid)
            {
                IdentityUser utilisateur = await gUtilisateur.FindByNameAsync(p_login.CodeUtilisateur);
                if (utilisateur != null)
                {
                    await gEnregistrement.SignOutAsync(); // Annule toutes les sessions de l'utilisateur.
                    Microsoft.AspNetCore.Identity.SignInResult résultat =
                        await gEnregistrement.PasswordSignInAsync(
                            utilisateur, p_login.MDP, false, false);
                    if (résultat.Succeeded)
                    {
                        DépôtEF.UtilisateurConnecté = true;
                        return Redirect(returnUrl ?? "/");
                    }
                }
                ModelState.AddModelError(nameof(ModèleLogin.CodeUtilisateur),
                "Utilisateur ou mot de passe invalide.");
            }
            return View(p_login);
        }
        [HttpGet]
        [Authorize(Roles = "Gérant")]
        public IActionResult AjouterUtilisateur()
        {
            ViewBag.Noms = "Arnaud Labrecque & Kevin Pugliese";
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Gérant")]
        public IActionResult Index()
        {
            ViewBag.Noms = "Arnaud Labrecque & Kevin Pugliese";
            return View(gUtilisateur.Users);
        }

        [HttpPost]
        [Authorize(Roles = "Gérant")]
        public async Task<IActionResult> AjouterUtilisateur(CréerUtilisateurModèle p_modèle)
        {
            ViewBag.Noms = "Arnaud Labrecque & Kevin Pugliese";

            //if (string.IsNullOrEmpty(p_utilisateur.NomUtilisateur))
            //    ModelState.AddModelError(nameof(Utilisateur.NomUtilisateur), "Entrez un nom d'utilisateur.");
            //else
            //{
            //    if (!Regex.Match(p_utilisateur.NomUtilisateur, @"^([a-zA-Z0-9]){6}$").Success)
            //        ModelState.AddModelError(nameof(Utilisateur.NomUtilisateur), "Entrez un nom d'utilisateur valide. (6 caractères, lettres et chiffres obligatoire)");
            //}

            //if (dépôt.Utilisateurs.Any(u => u.NomUtilisateur == p_utilisateur.NomUtilisateur))
            //    ModelState.AddModelError(nameof(Utilisateur.NomUtilisateur), "Entrez un nom d'utilisateur qui n'existe pas déjà.");


            //if (string.IsNullOrEmpty(p_utilisateur.MotDePasse))
            //    ModelState.AddModelError(nameof(Utilisateur.MotDePasse), "Entrez un mot de passe.");
            //else
            //{
            //    if (!Regex.Match(p_utilisateur.MotDePasse, @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8}$").Success)
            //        ModelState.AddModelError(nameof(Utilisateur.MotDePasse), "Entrez un mot de passe valide. (8 caractères, lettres et chiffres obligatoire)");
            //}

            //if (p_utilisateur.Rôle == Utilisateur.TypeUtilisateur.Administrateur) //Si le choix est "Choisissez un rôle" retourne Administrateur
            //    ModelState.AddModelError(nameof(Utilisateur.Rôle), "Choisissez un type d'utilisateur."); //Alors on valide s'il n'est pas Admin.


            //if (ModelState.IsValid)
            //{
            //    dépôt.AjouterUtilisateur(p_utilisateur);
            //    return View("../Utilisateur/Index");
            //}
            //else
            //    return View();

            if (ModelState.IsValid)
            {
                IdentityUser utilisateur = new IdentityUser
                {
                    UserName = p_modèle.CodeUtilisateur,
                    Email = p_modèle.Courriel,
                };
                IdentityResult résultat =
                    await gUtilisateur.CreateAsync(utilisateur, p_modèle.MDP);
                if (résultat.Succeeded)
                {
                    await gUtilisateur.AddToRoleAsync(utilisateur, p_modèle.Rôle.ToString());
                    return RedirectToAction("Index");
                    //return Redirect(returnUrl ?? "/");
                }
                else
                {
                    foreach (IdentityError erreur in résultat.Errors)
                    {
                        ModelState.AddModelError("", erreur.Description);
                    }
                }
            }
            return View(p_modèle);



        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await gEnregistrement.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public IActionResult AccèsRefusé()
        {
            return View();
        }
    }
}
