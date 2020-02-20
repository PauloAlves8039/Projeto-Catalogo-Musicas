using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TreinaWeb.Repositorios.Comum.Interface;

namespace TreinaWeb.Repositorios.Comum.Entity.Repositorio
{
    /// <summary>
    /// Classe de repositório genérica comum para uso do entity framework, herdando métodos da interface IRepositorioGenerico. 
    /// </summary>
    /// <remarks>Deve ser implementada em classes derivadas nos repositórios referentes as entidades da aplicação.</remarks>
    public class RepositorioGenericoEntity<TEntidade, TChave> : IRepositorioGenerico<TEntidade, TChave>
        where TEntidade : class
    {
        /// <value>Propriedade declarada para uso do DbContext.</value>
        private DbContext _contexto;

        /// <summary>
        /// Construtor sobrescrito para uso do DbContext.
        /// </summary>
        /// <param name="contexto">Parâmetro de referência para uso do DbContext.</param>
        public RepositorioGenericoEntity(DbContext contexto)
        {
            _contexto = contexto;
        }

        /// <summary>
        /// Método sobrescrito para alterar registro de entidade.
        /// </summary>
        /// <param name="entidade">Informa a entidade a ser alterada.</param>
        public void Alterar(TEntidade entidade)
        {
            _contexto.Set<TEntidade>().Attach(entidade);
            _contexto.Entry(entidade).State = EntityState.Modified;
            _contexto.SaveChanges();
        }

        /// <summary>
        /// Método sobrescrito para excluir registro de entidade.
        /// </summary>
        /// <param name="entidade">Informa a entidade a ser excluída</param>
        public void Excluir(TEntidade entidade)
        {
            _contexto.Set<TEntidade>().Attach(entidade);
            _contexto.Entry(entidade).State = EntityState.Deleted;
            _contexto.SaveChanges();
        }

        /// <summary>
        ///  Método sobrescrito para excluir registro de entidade por id.
        /// </summary>
        /// <param name="id">Informa o parâmetro de exclusão.</param>
        public void ExcluirPorId(TChave id)
        {
            TEntidade entidade = SelecionarPorId(id);
            Excluir(entidade);
        }

        /// <summary>
        /// Método sobrescrito para inserir registros da entidade.
        /// </summary>
        /// <param name="entidade">Informa a entidade a ser inserida.</param>
        public void Inserir(TEntidade entidade)
        {
            _contexto.Set<TEntidade>().Add(entidade);
            _contexto.SaveChanges();
        }

        /// <summary>
        /// Método sobrescrito para selecionar lista da entidade.
        /// </summary>
        /// <returns>Lista de registros da entidade.</returns>
        public List<TEntidade> Selecionar()
        {
            return _contexto.Set<TEntidade>().ToList();
        }

        /// <summary>
        /// Método sobrescrito para selecionar registro da entidade por id.
        /// </summary>
        /// <param name="id">Parâmetro de pesquisa de registro.</param>
        /// <returns>Registro da entiddade por id.</returns>
        public TEntidade SelecionarPorId(TChave id)
        {
            return _contexto.Set<TEntidade>().Find(id);
        }
    }
}
