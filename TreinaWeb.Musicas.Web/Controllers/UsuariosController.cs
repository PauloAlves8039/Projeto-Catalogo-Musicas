using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TreinaWeb.Musicas.Web.Identity;
using TreinaWeb.Musicas.Web.ViewModels.Usuario;

namespace TreinaWeb.Musicas.Web.Controllers
{
    /// <summary>
    /// Controlador responsável pelas ações referentes ao usuário.
    /// </summary>
    public class UsuariosController : Controller
    {
        /// <summary>
        /// Action para criação de novo usuário.
        /// </summary>
        /// <returns>Para a view referente ao usuário.</returns>
        public ActionResult CriarUsuario()
        {
            return View();
        }

        /// <summary>
        /// Action para criação de novo usuário recebidas pelo UsuarioViewModel.
        /// </summary>
        /// <param name="viewModel">Representa o contexto do UsuarioViewModel.</param>
        /// <returns>Para a view do usuário.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CriarUsuario(UsuarioViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var userStore = new UserStore<IdentityUser>(new MusicasIdentityDbContext());
                var userManager = new UserManager<IdentityUser>(userStore);
                var identityUser = new IdentityUser
                {
                    UserName = viewModel.Email,
                    Email = viewModel.Email
                };
                IdentityResult resultado = userManager.Create(identityUser, viewModel.Senha);
                if (resultado.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("erro_identity", resultado.Errors.First());
                    return View(viewModel);
                }
            }
            return View(viewModel);
        }

        /// <summary>
        /// Action para realização do login do usuário.
        /// </summary>
        /// <param name="viewModel">Representa o contexto do UsuarioViewModel.</param>
        /// <returns>Para a view do usuário.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UsuarioViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var userStore = new UserStore<IdentityUser>(new MusicasIdentityDbContext());
                var userManager = new UserManager<IdentityUser>(userStore);
                var usuario = userManager.Find(viewModel.Email, viewModel.Senha);
                if (usuario == null)
                {
                    ModelState.AddModelError("erro_identity", "Usuário e/ou senha incorretos!");
                    return View(viewModel);
                }
                var authManager = HttpContext.GetOwinContext().Authentication;
                var identity = userManager.CreateIdentity(usuario, DefaultAuthenticationTypes.ApplicationCookie);
                authManager.SignIn(new Microsoft.Owin.Security.AuthenticationProperties
                {
                    IsPersistent = false
                }, identity);
                return RedirectToAction("Index", "Home");
            }
            return View(viewModel);
        }

        /// <summary>
        /// Action para realização do logoof do usuário.
        /// </summary>
        /// <returns>Para a view index da aplicação.</returns>
        public ActionResult Logoff()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}