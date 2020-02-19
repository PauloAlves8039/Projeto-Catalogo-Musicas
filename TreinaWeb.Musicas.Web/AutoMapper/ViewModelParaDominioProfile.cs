using AutoMapper;
using TreinaWeb.Musicas.Dominio.Dominio;
using TreinaWeb.Musicas.Web.ViewModels.Album;
using TreinaWeb.Musicas.Web.ViewModels.Musica;

namespace TreinaWeb.Musicas.Web.AutoMapper
{
    /// <summary>
    /// Classe responsável pela configuração do AutoMapper convertendo ViewModel para Dominio herando a classe Profile. 
    /// </summary>
    public class ViewModelParaDominioProfile : Profile
    {
        /// <summary>
        /// Construtor sobrescrito para criar um mapeamento entre objetos Album e Musica.
        /// </summary>
        /// <remarks>
        /// Utilizado o método CreateMap da classe Mapper para o mapeamento dos objetos
        /// </remarks>
        public ViewModelParaDominioProfile()
        {
            CreateMap<AlbumViewModel, Album>();
            CreateMap<MusicaViewModel, Musica>();
        }
    }
}