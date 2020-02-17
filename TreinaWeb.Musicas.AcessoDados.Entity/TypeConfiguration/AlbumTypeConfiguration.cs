using TreinaWeb.Musicas.Comum.Entity.Abstract;
using TreinaWeb.Musicas.Dominio.Dominio;

namespace TreinaWeb.Musicas.AcessoDados.Entity.TypeConfiguration
{
    /// <summary>
    /// Classe responsável por herdar métodos da classe TreinaWebEntityAbstractConfig, com a finalidade de realizar configurações da entidade Album no banco de dados.    
    /// </summary>
    class AlbumTypeConfiguration : TreinaWebEntityAbstractConfig<Album>
    {
        /// <summary>
        /// Método sobrescrito para configurar os campos da tabela ALB_ALBUNS.
        /// </summary>
        protected override void ConfigurarCampoTabela()
        {
            Property(p => p.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .HasColumnName("ALB_ID");

            Property(p => p.Nome)
                .IsRequired()
                .HasColumnName("ALB_NOME")
                .HasMaxLength(100);

            Property(p => p.Ano)
                .IsRequired()
                .HasColumnName("ALB_ANO");

            Property(p => p.Email)
                .IsRequired()
                .HasColumnName("ALB_EMAIL")
                .HasMaxLength(100);

            Property(P => P.Observacoes)
                .IsRequired()
                .HasColumnName("ALB_OBSERVACOES")
                .HasMaxLength(1000);

        }

        /// <summary>
        /// Método sobrescrito para configurar a chave primaria da tabela ALB_ALBUNS.
        /// </summary>
        protected override void ConfigurarChavePrimaria()
        {
            HasKey(pk => pk.Id);
        }

        /// <summary>
        /// Método sobrescrito para configurar chave estrangeira da tabela ALB_ALBUNS para a tabela referente a entidade Musicas.
        /// </summary>
        protected override void ConfigurarChavesEstrangeiras()
        {
            HasMany(p => p.Musicas)
                .WithRequired(p => p.Album)
                .HasForeignKey(fk => fk.IdAlbum);
        }

        /// <summary>
        /// Método sobrescrito para configurar o nome da tabela para ALB_ALBUNS.
        /// </summary>
        protected override void ConfigurarNomeTabela()
        {
            ToTable("ALB_ALBUNS");
        }
    }
}
