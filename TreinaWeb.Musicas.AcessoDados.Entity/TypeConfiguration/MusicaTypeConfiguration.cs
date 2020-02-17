using TreinaWeb.Musicas.Comum.Entity.Abstract;
using TreinaWeb.Musicas.Dominio.Dominio;

namespace TreinaWeb.Musicas.AcessoDados.Entity.TypeConfiguration
{
    /// <summary>
    /// Classe responsável por herdar métodos da classe TreinaWebEntityAbstractConfig, com a finalidade de realizar configurações da entidade Musica no banco de dados. 
    /// </summary>
    class MusicaTypeConfiguration : TreinaWebEntityAbstractConfig<Musica>
    {
        /// <summary>
        /// Método sobrescrito para configurar os campos da tabela MUS_MUSICAS
        /// </summary>
        protected override void ConfigurarCampoTabela()
        {
            Property(p => p.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .HasColumnName("MUS_ID");

            Property(p => p.Nome)
                .IsRequired()
                .HasColumnName("MUS_NOME")
                .HasMaxLength(100);

            Property(p => p.IdAlbum)
                .IsRequired()
                .HasColumnName("ALB_ID");
        }

        /// <summary>
        /// Método sobrescrito para configurar a chave primaria da tabela MUS_MUSICAS
        /// </summary>
        protected override void ConfigurarChavePrimaria()
        {
            HasKey(pk => pk.Id);
        }

        /// <summary>
        /// Método sobrescrito para configurar chave estrangeira da tabela MUS_MUSICAS para a tabela referente a entidade Album.
        /// </summary>
        protected override void ConfigurarChavesEstrangeiras()
        {
            HasRequired(p => p.Album)
                .WithMany(p => p.Musicas)
                .HasForeignKey(fk => fk.IdAlbum);
        }

        /// <summary>
        /// Método sobrescrito para configurar o nome da tabela para MUS_MUSICAS
        /// </summary>
        protected override void ConfigurarNomeTabela()
        {
            ToTable("MUS_MUSICAS");
        }
    }
}
