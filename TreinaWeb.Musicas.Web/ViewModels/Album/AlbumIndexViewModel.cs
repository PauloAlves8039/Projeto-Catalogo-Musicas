using System.ComponentModel.DataAnnotations;

namespace TreinaWeb.Musicas.Web.ViewModels.Album
{
    /// <summary>
    /// Classe de modelo usada para iteração de suas propriedades com a view Albuns, utilizando Data Annotations para exibição dessas propriedades.
    /// </summary>
    public class AlbumIndexViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nome do álbum")]
        public string Nome { get; set; }

        [Display(Name = "Ano do álbum")]
        public int Ano { get; set; }

        [Display(Name = "Email de contato")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Observações")]
        public string Observacoes { get; set; }
    }
}