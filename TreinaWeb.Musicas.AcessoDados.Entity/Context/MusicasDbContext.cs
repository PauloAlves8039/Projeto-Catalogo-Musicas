using System.Data.Entity;
using TreinaWeb.Musicas.Dominio.Dominio;

namespace TreinaWeb.Musicas.AcessoDados.Entity.Context
{
    /// <summary>
    /// Classe responsável por herda contexto da classe DbContext para uso do Entity Framework no mapeamento do banco de dados.
    /// </summary>
    public class MusicasDbContext : DbContext
    {
        /// <value>Representa o domínio Album como uma tabela no banco de dados através do DbSet.</value>
        public DbSet<Album> Albuns { get; set; }

        /// <value>Representa o domínio Musica como uma tabela no banco de dados através do DbSet.</value>
        public DbSet<Musica> Musicas { get; set; }
    }
}
