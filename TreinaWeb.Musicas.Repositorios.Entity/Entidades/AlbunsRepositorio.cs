using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TreinaWeb.Musicas.AcessoDados.Entity.Context;
using TreinaWeb.Musicas.Dominio.Dominio;
using TreinaWeb.Repositorios.Comum.Entity.Repositorio;

namespace TreinaWeb.Musicas.Repositorios.Entity.Entidades
{
    /// <summary>
    /// Classe que representa repositório da entidade Album, herdando métodos da classe RepositorioGenericoEntity.
    /// </summary>
    public class AlbunsRepositorio : RepositorioGenericoEntity<Album, int>
    {
        /// <summary>
        /// Construtor sobrescrito para uso do DbContext.
        /// </summary>
        /// <param name="contexto">Parâmetro de referência para uso do DbContext.</param>
        public AlbunsRepositorio(MusicasDbContext contexto)
            : base(contexto)
        {

        }

        /// <summary>
        /// Método sobrescrito para selecionar álbum.
        /// </summary>
        /// <returns>Lista de álbuns.</returns>
        public override List<Album> Selecionar()
        {
            return _contexto.Set<Album>().Include(p => p.Musicas).ToList();
        }

        /// <summary>
        /// Método sobrescrito para selecionar álbum por id.
        /// </summary>
        /// <param name="id">Parâmetro de pesquisa de álbum.</param>
        /// <returns>Álbum selecionado por id.</returns>
        public override Album SelecionarPorId(int id)
        {
            return _contexto.Set<Album>().Include(p => p.Musicas).SingleOrDefault(a => a.Id == id);
        }
    }
}
