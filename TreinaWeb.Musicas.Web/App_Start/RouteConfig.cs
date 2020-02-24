using System.Web.Mvc;
using System.Web.Routing;

namespace TreinaWeb.Musicas.Web
{
    /// <summary>
    /// Classe responsável pelas configurações das rotas da aplicação.
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// Método responsável por registrar as rotas.
        /// </summary>
        /// <param name="routes">Parâmentro referente a coleção de rotas</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "PesquisarAlbum",
                url: "Albuns/PesquisarPorNome/{pesquisa}",
                defaults: new { Controller = "Albuns", action = "FiltrarPorNome", pesquisa = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
