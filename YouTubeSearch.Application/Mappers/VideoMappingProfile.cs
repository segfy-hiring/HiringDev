using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeSearch.Application.Commands;
using YouTubeSearch.Application.Responses;
using YouTubeSearch.Core.Entities;

namespace YouTubeSearch.Application.Mappers
{
    public class VideoMappingProfile : Profile
    {
        public VideoMappingProfile()
        {
            CreateMap<Video, SearchResponse>().ReverseMap();
            CreateMap<Video, CreateVideoCommand>().ReverseMap();
            CreateMap<Video, VideoResponse>().ReverseMap();
        }
    }
}
