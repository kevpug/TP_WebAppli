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
        private IDépôt dépôt;

        public UtilisateurController(IDépôt p_dépôt, UserManager<IdentityUser> p_gu,
        SignInManager<IdentityUser> p_ge)
        {
            dépôt = p_dépôt;
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
        [Authorize(Roles = "Gerant")]
        public IActionResult AjouterUtilisateur()
        {
            ViewBag.Noms = "Arnaud Labrecque & Kevin Pugliese";
            ViewBag.User = HttpContext.User.Identity.Name;
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Gerant")]
        public async Task<IActionResult> AjouterUtilisateur(CréerUtilisateurModèle p_modèle)
        {
            ViewBag.Noms = "Arnaud Labrecque & Kevin Pugliese";


            if (!string.IsNullOrEmpty(p_modèle.CodeUtilisateur))
                if (!Regex.Match(p_modèle.CodeUtilisateur, @"^([a-zA-Z0-9]){6}$").Success)
                    ModelState.AddModelError(nameof(CréerUtilisateurModèle.CodeUtilisateur), "Entrez un code d'utilisateur valide. (6 caractères, lettres et chiffres obligatoire)");
            if (!string.IsNullOrEmpty(p_modèle.MDP))
                if (!Regex.Match(p_modèle.MDP, @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8}$").Success)
                    ModelState.AddModelError(nameof(CréerUtilisateurModèle.MDP), "Entrez un mot de passe valide. (8 caractères, lettres et chiffres obligatoire)");

            if (!string.IsNullOrEmpty(p_modèle.Courriel))
                if (!Regex.Match(p_modèle.Courriel, @"^([\w.-]+)@([\w-]+)((.(\w){2,3})+)$").Success)
                    ModelState.AddModelError(nameof(CréerUtilisateurModèle.Courriel), "Entrez un courriel valide. (xxxxx@xxxxx.xxx)");
                else
                {
                    if (dépôt.Utilisateurs.Any(u => u.Email == p_modèle.Courriel))
                        ModelState.AddModelError(nameof(CréerUtilisateurModèle.Courriel), "Ce courriel est déjà utilisé.");

                }

            if (dépôt.Utilisateurs.Any(u => u.UserName == p_modèle.CodeUtilisateur))
                ModelState.AddModelError(nameof(CréerUtilisateurModèle.CodeUtilisateur), "Ce code d'utilisateur est déjà utilisé.");
            
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
                    return Redirect("../Home/Index");
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
            DépôtEF.UtilisateurConnecté = false;
            return Redirect("../Home/Index");
        }

        [AllowAnonymous]
        public IActionResult AccèsRefusé()
        {
            ViewBag.User = HttpContext.User.Identity.Name;
            ViewBag.Noms = "Arnaud Labrecque & Kevin Pugliese";
            return View();
        }
    }
}
