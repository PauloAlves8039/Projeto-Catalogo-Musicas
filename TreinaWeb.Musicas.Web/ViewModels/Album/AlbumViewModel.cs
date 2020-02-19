using System.ComponentModel.DataAnnotations;

namespace TreinaWeb.Musicas.Web.ViewModels.Album
{
    /// <summary>
    /// Classe usada para iteração das propriedades do domínio Album para as views de inclusão e edição, utilizando Data Annotations para validação dessas propriedades.
    /// </summary>
    public class AlbumViewModel
    {
        [Required(ErrorMessage = "O Id do álbum é obrigatório!")]
        public int Id { get; set; }

        [Display(Name = "Nome do álbum")]
        [Required(ErrorMessage = "O nome do álbum é obrigatório!")]
        [MaxLength(100, ErrorMessage = "O nome do álbum poderá ter no máximo 100 caracteres!")]
        public string Nome { get; set; }

        [Display(Name = "Ano do álbum")]
        [Required(ErrorMessage = "O ano do álbum é obrigatório!")]
        public int Ano { get; set; }

        [Display(Name = "Email de contato")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "O email é obrigatório!")]
        [MaxLength(100, ErrorMessage = "O email não pode ter mais do que 100 caracteres!")]
        public string Email { get; set; }

        [Display(Name = "Observações")]
        [MaxLength(1000, ErrorMessage = "Você excedeu a quantidade de caracteres para a observação, que é no máximo 1000!")]
        public string Observacoes { get; set; }
    }
}