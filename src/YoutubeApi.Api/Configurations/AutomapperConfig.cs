using AutoMapper;
using YoutubeApi.Api.Models;
using YoutubeAPI.Business.Models;

namespace YoutubeApi.Api.Configurations
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Favorite, SearchViewModel>()
                .ReverseMap();

            CreateMap<Pagination, PaginationViewModel>()
                .ForMember(dest => dest.Searches, o => o.MapFrom(x => x.Favorites))
                .ReverseMap();

        }
    }
}
