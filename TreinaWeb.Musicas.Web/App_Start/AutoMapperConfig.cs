using AutoMapper;
using TreinaWeb.Musicas.Web.AutoMapper;

namespace TreinaWeb.Musicas.Web.App_Start
{
    /// <summary>
    /// Classe responsável pelo carregamento das configurações do AutoMapper na inicialização da aplicação.
    /// </summary>
    public static class AutoMapperConfig
    {
        /// <summary>
        /// Este método realiza adição da configuração de perfil do AutoMapper.
        /// </summary>
        /// <remarks>
        /// É utilizado o método Initialize da classe Mapper passando as classes que serão carregadas na inicialização da aplicação.
        /// </remarks>
        public static void Configurar()
        {
            Mapper.Initialize(cfg => 
            {
                cfg.AddProfile<DominioParaViewModelProfile>();
                cfg.AddProfile<ViewModelParaDominioProfile>();
            });
        }
    }
}