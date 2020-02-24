using System.Web.Mvc;
using TreinaWeb.Musicas.Web.Filter;

namespace TreinaWeb.Musicas.Web
{
    /// <summary>
    /// Classe responsável por armazenar as configurações globais dos filtros.
    /// </summary>
    public class FilterConfig
    {
        /// <summary>
        /// Método responsável registrar as configurações globais dos filtros.
        /// </summary>
        /// <param name="filters">Parâmetro de uso da coleção de filtros.</param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LogActionFilter());
            filters.Add(new LogResultFilter());
        }
    }
}
