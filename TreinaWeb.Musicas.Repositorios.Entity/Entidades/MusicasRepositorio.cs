using TreinaWeb.Musicas.AcessoDados.Entity.Context;
using TreinaWeb.Musicas.Dominio.Dominio;
using TreinaWeb.Repositorios.Comum.Entity.Repositorio;

namespace TreinaWeb.Musicas.Repositorios.Entity.Entidades
{
    /// <summary>
    /// Classe que representa repositório da entidade Musica, herdando métodos da classe RepositorioGenericoEntity.
    /// </summary>
    public class MusicasRepositorio : RepositorioGenericoEntity<Musica, long>
    {
        /// <summary>
        /// Construtor sobrescrito para uso do DbContext.
        /// </summary>
        /// <param name="contexto">Parâmetro de referência para uso do DbContext.</param>
        public MusicasRepositorio(MusicasDbContext contexto)
            : base (contexto)
        {

        }
    }
}
