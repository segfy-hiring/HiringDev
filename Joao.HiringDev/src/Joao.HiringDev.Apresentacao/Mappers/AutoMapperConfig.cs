using AutoMapper;
using Joao.HiringDev.Apresentacao.Models.Home;
using Joao.HiringDev.Dominio.Entidades;

namespace Joao.HiringDev.Apresentacao.Mappers
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<VideoYoutube, VideoYoutubeViewModel>().ReverseMap();            
            CreateMap<CanalYoutube, CanalYoutubeViewModel>().ReverseMap();            
        }
    }
}
