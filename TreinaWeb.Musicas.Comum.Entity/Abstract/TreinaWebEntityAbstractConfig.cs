using System.Data.Entity.ModelConfiguration;

namespace TreinaWeb.Musicas.Comum.Entity.Abstract
{
    /// <summary>
    /// Classe de template genérica e abstrata, contém métodos responsáveis pelas configurações das entidades no banco de dados.
    /// </summary>
    public abstract class TreinaWebEntityAbstractConfig<TEntidade> : EntityTypeConfiguration<TEntidade>
        where TEntidade : class
    {
        /// <summary>
        /// Construtor para definir sequência de métodos genéricos na criação de tabelas no banco de dados.
        /// </summary>
        public TreinaWebEntityAbstractConfig()
        {
            ConfigurarNomeTabela();
            ConfigurarCampoTabela();
            ConfigurarChavePrimaria();
            ConfigurarChavesEstrangeiras();
        }

        /// <summary>
        /// Método abstrato para configurar chave estrangeira.
        /// </summary>
        protected abstract void ConfigurarChavesEstrangeiras();

        /// <summary>
        /// Método abstrato para configurar chave primaria.
        /// </summary>
        protected abstract void ConfigurarChavePrimaria();

        /// <summary>
        /// Método abstrato para configurar campos da tabela.
        /// </summary>
        protected abstract void ConfigurarCampoTabela();

        /// <summary>
        /// Método abstrato para configurar o nome da tabela.
        /// </summary>
        protected abstract void ConfigurarNomeTabela();
    }
}
