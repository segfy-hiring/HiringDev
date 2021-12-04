using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeSearch.Application.Mappers;
using YouTubeSearch.Application.Queries;
using YouTubeSearch.Application.Responses;
using YouTubeSearch.Core.Repositories;

namespace YouTubeSearch.Application.Handlers
{
    public interface IGetVideoNameHandler
    {
        List<SearchResponse> Handle(GetVideoNameRequest command);
    }

    public class GetVideoByNameHandler : IGetVideoNameHandler
    {
        IVideoRepository _repository;

        public GetVideoByNameHandler(IVideoRepository repository)
        {
            _repository = repository;
        }
        public List<SearchResponse> Handle(GetVideoNameRequest command)
        {
            var videos = _repository.GetByName(command.Name);

            return VideoMapper.Mapper.Map<List<SearchResponse>>(videos);
        }
    }
}
