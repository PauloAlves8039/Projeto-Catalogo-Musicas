using AutoMapper;
using TreinaWeb.Musicas.Dominio.Dominio;
using TreinaWeb.Musicas.Web.ViewModels.Album;
using TreinaWeb.Musicas.Web.ViewModels.Musica;

namespace TreinaWeb.Musicas.Web.AutoMapper
{
    /// <summary>
    /// Classe responsável pela configuração do AutoMapper convertendo Dominio para ViewModel herando a classe Profile. 
    /// </summary>
    public class DominioParaViewModelProfile : Profile
    {
        /// <summary>
        /// Construtor sobrescrito para criar um mapeamento entre objetos.
        /// </summary>
        /// <remarks>
        /// É usado nesse construtor o método CreateMap da classe Mapper para o mapeamento dos objetos.
        /// </remarks>
        public DominioParaViewModelProfile()
        {
            CreateMap<Album, AlbumIndexViewModel>()
                .ForMember(p => p.Nome, opt => 
                {
                    opt.MapFrom(src => string.Format("{0} ({1})", src.Nome, src.Ano.ToString()));
                });
            CreateMap<Album, AlbumViewModel>();

            CreateMap<Musica, MusicaIndexViewModel>()
                .ForMember(p => p.NomeAlbum, opt => 
                {
                    opt.MapFrom(src => src.Album.Nome);
                });
            CreateMap<Musica, MusicaViewModel>();
        }
    }
}