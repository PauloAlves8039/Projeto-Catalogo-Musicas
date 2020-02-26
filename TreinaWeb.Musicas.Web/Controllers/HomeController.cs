using System.Web.Mvc;

namespace TreinaWeb.Musicas.Web.Controllers
{
    /// <summary>
    /// Controlador responsável pelo ponto de entrada da aplicação
    /// </summary>
    [AllowAnonymous]
    public class HomeController : Controller
    {
        /// <summary>
        /// Action responsável pelo direcionamento ate a página index.
        /// </summary>
        /// <returns>Retorna view home.</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Action responsável pelo direcionamento ate a página about.
        /// </summary>
        /// <returns>Retorna view about.</returns>
        public ActionResult About()
        {
            ViewBag.Message = "Página de descrição do TreinaWeb Músicas.";

            return View();
        }

        /// <summary>
        /// Action responsável pelo direcionamento ate a página contact.
        /// </summary>
        /// <returns>Retorna view contact.</returns>
        public ActionResult Contact()
        {
            ViewBag.Message = "Página de contato.";

            return View();
        }
    }
}