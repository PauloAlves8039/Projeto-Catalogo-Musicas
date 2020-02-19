using System.ComponentModel.DataAnnotations;

namespace TreinaWeb.Musicas.Web.ViewModels.Musica
{
    /// <summary>
    /// Classe usada para iteração das propriedades do domínio Musica para as views de inclusão e edição, utilizando Data Annotations para validação dessas propriedades.
    /// </summary>
    public class MusicaViewModel
    {
        [Required(ErrorMessage = "O Id é obrigatório!")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório!")]
        [MaxLength(100, ErrorMessage = "O Nome da música pode ter no máximo 100 caracteres!")]
        [Display(Name = "Nome da música")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Selecione um álbum válido!")]
        [Display(Name = "Álbum")]
        public string IdAlbum { get; set; }
    }
}