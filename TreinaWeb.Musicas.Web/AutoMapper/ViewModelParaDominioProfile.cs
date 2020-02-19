using AutoMapper;
using TreinaWeb.Musicas.Dominio.Dominio;

namespace TreinaWeb.Musicas.Web.AutoMapper
{
    /// <summary>
    /// Classe responsável pela configuração do AutoMapper convertendo ViewModel para Dominio herando a classe Profile. 
    /// </summary>
    public class ViewModelParaDominioProfile : Profile
    {
        public ViewModelParaDominioProfile()
        {
            CreateMap<AlbumViewModel, Album>();
            CreateMap<MusicaViewModel, Musica>();
        }
    }
}