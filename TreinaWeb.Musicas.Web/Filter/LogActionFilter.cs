using System;
using System.Diagnostics;
using System.Web.Mvc;

namespace TreinaWeb.Musicas.Web.Filter
{
    /// <summary>
    /// Classe responsável por gerar filtros com logs referentes as informações da aplicação, herdando métodos da interface IActionFilter.
    /// </summary>
    public class LogActionFilter : FilterAttribute, IActionFilter
    {
        /// <summary>
        /// Método sobrescrito para execução de uma action quando for finalizada.
        /// </summary>
        /// <param name="filterContext">Parâmetro de uso do contexto do filtro.</param>
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string mensagem = string.Format("[{0}] Finalizou: {1}/{2}",
                                            DateTime.Now.ToString(),
                                            filterContext.RouteData.Values["Controller"].ToString(),
                                            filterContext.RouteData.Values["Action"].ToString());
            Debug.WriteLine(mensagem);
        }

        /// <summary>
        /// Método sobrescrito para execução de uma action quando for inicializada.
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string mensagem = string.Format("[{0}] Iniciou: {1}/{2}",
                                            DateTime.Now.ToString(),
                                            filterContext.RouteData.Values["Controller"].ToString(),
                                            filterContext.RouteData.Values["Action"].ToString());
            Debug.WriteLine(mensagem);
        }
    }
}