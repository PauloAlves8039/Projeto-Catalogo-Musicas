using System.Collections.Generic;

namespace TreinaWeb.Repositorios.Comum.Interface
{
    /// <summary>
    /// Interface com métodos genéricos para utilização de um CRUD.
    /// </summary>
    /// <remarks>Deve ser implementada nas classes derivadas nos repositórios.</remarks>
    public interface IRepositorioGenerico<TEntidade, TChave> where TEntidade : class
    {
        /// <summary>
        /// Método genérico para exibir lista da entidade.
        /// </summary>
        /// <returns>Lista de registros da entidade.</returns>
        List<TEntidade> Selecionar();

        /// <summary>
        /// Método genérico para selecionar registro da entidade por id.
        /// </summary>
        /// <param name="id">Parâmentro de pesquisa de registro.</param>
        /// <returns>O registro pesquisado por id.</returns>
        TEntidade SelecionarPorId(TChave id);

        /// <summary>
        /// Método genérico para inserir registro da entidade.
        /// </summary>
        /// <param name="entidade">Informa a entidade a ser inserida.</param>
        void Inserir(TEntidade entidade);

        /// <summary>
        /// Método genérico para alterar registro da entidade.
        /// </summary>
        /// <param name="entidade">Informa a entidade a ser alterada.</param>
        void Alterar(TEntidade entidade);

        /// <summary>
        /// Métoddo genérico para excluir registro da entidade.
        /// </summary>
        /// <param name="entidade">Informa o objeto a ser excluído.</param>
        void Excluir(TEntidade entidade);

        /// <summary>
        /// Métoddo genérico para excluir registro da entidade por id.
        /// </summary>
        /// <param name="id">Informa o parâmetro de exclusão.</param>
        void ExcluirPorId(TChave id);
    }
}
