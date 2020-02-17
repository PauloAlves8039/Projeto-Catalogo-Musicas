using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TreinaWeb.Musicas.AcessoDados.Entity.TypeConfiguration;
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

        /// <summary>
        /// Construtor sobrescrito para configurar o carregamento de dados.
        /// </summary>
        public MusicasDbContext()
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        /// <summary>
        /// Método sobrescrito para configuração dos modelos das entidades no banco de dados.
        /// </summary>
        /// <param name="modelBuilder">Propriedade responsável pela criação de relação entre as entidades no banco de dados.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AlbumTypeConfiguration());
            modelBuilder.Configurations.Add(new MusicaTypeConfiguration());
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            //modelBuilder.Properties()
            //    .Configure(p => p.HasColumnType("varchar"));
        }
    }
}
