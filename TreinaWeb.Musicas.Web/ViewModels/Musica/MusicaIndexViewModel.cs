using System.ComponentModel.DataAnnotations;

namespace TreinaWeb.Musicas.Web.ViewModels.Musica
{
    /// <summary>
    /// Classe de modelo usada para iteração de suas propriedades com a view Musicas, utilizando Data Annotations para exibição dessas propriedades.
    /// </summary>
    public class MusicaIndexViewModel
    {
        [Required(ErrorMessage = "O Id é obrigatório!")]
        public long Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório!")]
        [MaxLength(100, ErrorMessage = "O nome da música pode ter no máximo 100 caractereres!")]
        [Display(Name = "Nome da música!")]
        public string Nome { get; set; }

        [Display(Name = "Álbum")]
        public string IdAlbum { get; set; }
    }
}