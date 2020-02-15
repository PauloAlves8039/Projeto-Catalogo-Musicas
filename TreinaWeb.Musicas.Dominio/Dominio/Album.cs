using System.Collections.Generic;

namespace TreinaWeb.Musicas.Dominio.Dominio
{
    /// <summary>
    /// Classe responsável por representar o domínio Album.
    /// </summary>
    public class Album
    {
        /// <value>Implementa o id do álbum.</value>
        public int Id { get; set; }

        /// <value>Representa o nome do álbum.</value>
        public string Nome { get; set; }

        /// <value>Imforma o ano de lançamento do álbum.</value>
        public int Ano { get; set; }

        /// <value>Atribui um email ao álbum.</value>
        public string Email { get; set; }

        /// <value>Imforma qualquer detalhe referente álbum.</value>
        public string Observacoes { get; set; }

        /// <value>Exibe uma lista de músicas.</value>
        public virtual List<Musica> Musicas { get; set; }
    }
}
