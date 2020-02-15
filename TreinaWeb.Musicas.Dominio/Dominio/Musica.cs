namespace TreinaWeb.Musicas.Dominio.Dominio
{
    /// <summary>
    /// Classe responsável por representar o domínio música.
    /// </summary>
    public class Musica
    {
        /// <value>Implementa o id da música.</value>
        public long Id { get; set; }

        /// <value>Representa o nome da música.</value>
        public string Nome { get; set; }

        /// <value>Responsável pela declaração da música a um álbum.</value>
        public virtual Album Album { get; set; }

        /// <value>Atribui uma música a um álbum.</value>
        public int IdAlbum { get; set; }
    }
}
