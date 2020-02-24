using System;
using System.Diagnostics;
using System.Web.Mvc;

namespace TreinaWeb.Musicas.Web.Filter
{
    /// <summary>
    /// Classe responsável por gerar resultado dos filtros com logs referente as informações da aplicação, herdando métodos da interface IResultFilter.
    /// </summary>
    public class LogResultFilter : FilterAttribute, IResultFilter
    {
        /// <summary>
        /// Método sobrescrito para informar o resultado do processamento de uma action finalizada.
        /// </summary>
        /// <param name="filterContext">Parâmetro de uso do contexto do filtro.</param>
        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            string mensagem = string.Format("[{0}] Resultado: {1}/{2} | {3}",
                                            DateTime.Now.ToString(),
                                            filterContext.RouteData.Values["Controller"].ToString(),
                                            filterContext.RouteData.Values["Action"].ToString(),
                                            filterContext.Result.ToString());
            Debug.WriteLine(mensagem);
        }

        /// <summary>
        /// Método sobrescrito para informar o resultado do processamento de uma action iniciada.
        /// </summary>
        /// <param name="filterContext">Parâmetro de uso do contexto do filtro.</param>
        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            string mensagem = string.Format("[{0}] Processsando Resultados...: {1}/{2} | {3}",
                                            DateTime.Now.ToString(),
                                            filterContext.RouteData.Values["Controller"].ToString(),
                                            filterContext.RouteData.Values["Action"].ToString(),
                                            filterContext.Result.ToString());
            Debug.WriteLine(mensagem);
        }
    }
}