using System.ComponentModel.DataAnnotations;

namespace TreinaWeb.Musicas.Web.ViewModels.Musica
{
    /// <summary>
    /// Classe de modelo usada para iteração de suas propriedades com a view Musicas, utilizando Data Annotations para exibição dessas propriedades.
    /// </summary>
    public class MusicaIndexViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nome da música")]
        public string Nome { get; set; }

        [Display(Name = "Nome do álbum")]
        public string NomeAlbum { get; set; }
    }
}