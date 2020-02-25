using Microsoft.AspNet.Identity.EntityFramework;

namespace TreinaWeb.Musicas.Web.Identity
{
    /// <summary>
    /// Classe para uso do contexto referente ao Identity herdando características da classe IdentityDbContext.
    /// </summary>
    /// <remarks>Deve ser implementada no controlador UsuariosController.</remarks>
    public class MusicasIdentityDbContext : IdentityDbContext<IdentityUser>
    {
        /// <summary>
        /// Construtor sobrescrito para referenciar a classe MusicasDbContext.
        /// </summary>
        public MusicasIdentityDbContext()
            : base("MusicasDbContext")
        {

        }
    }
}