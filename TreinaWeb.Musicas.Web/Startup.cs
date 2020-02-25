using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(TreinaWeb.Musicas.Web.Startup))]

namespace TreinaWeb.Musicas.Web
{
    /// <summary>
    /// Classe responsável pela configuração do Microsoft Owin.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Método responsável pela configuração de ação do Owin na aplicação.
        /// </summary>
        /// <param name="app">Representa o contexto das configurações do Owin.</param>
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Usuarios/Login"),

            });
        }
    }
}
