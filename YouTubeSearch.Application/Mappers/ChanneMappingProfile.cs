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
    public class ChannelMappingProfile : Profile
    {
        public ChannelMappingProfile()
        {
            CreateMap<Channel, SearchResponse>().ReverseMap();
            CreateMap<Channel, ChannelResponse>().ReverseMap();
            CreateMap<Channel, CreateChannelCommand>().ReverseMap();
        }
    }
}
