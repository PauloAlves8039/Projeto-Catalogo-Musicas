using System.ComponentModel.DataAnnotations;

namespace TreinaWeb.Musicas.Web.ViewModels.Usuario
{
    /// <summary>
    /// Classe responsável pela representação da entidade Usuario.
    /// </summary>
    public class UsuarioViewModel
    {
        /// <value>Informa o email do usuário.</value>
        [Required(ErrorMessage = "O email é obrigatório!")]
        [MaxLength(50, ErrorMessage = "O email não pode ter mais de 50 caracteres.")]
        public string Email { get; set; }

        /// <value>Informa a senha do usuário.</value>
        [Required(ErrorMessage = "A senha é obrigatória!")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}