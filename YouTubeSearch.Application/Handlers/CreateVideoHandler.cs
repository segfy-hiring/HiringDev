using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YouTubeSearch.Application.Commands;
using YouTubeSearch.Application.Mappers;
using YouTubeSearch.Application.Responses;
using YouTubeSearch.Core.Entities;
using YouTubeSearch.Core.Repositories;

namespace YouTubeSearch.Application.Handlers
{
    public class CreateVideoHandler : IRequestHandler<CreateVideoCommand, VideoResponse>
    {
        private readonly IVideoRepository _videoRepository;
        public CreateVideoHandler(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }
        public async Task<VideoResponse> Handle(CreateVideoCommand request, CancellationToken cancellationToken)
        {
            var videoEntity = VideoMapper.Mapper.Map<Video>(request);
            videoEntity.DateCreated = DateTime.Now;
            videoEntity.PublishDate = DateTime.Now;

            if (videoEntity is null)
                throw new ApplicationException("Issue with mapper");

            if (_videoRepository.GetByYoutubeId(request.YoutubeId) != null || _videoRepository.GetByName(request.Name) != null)
                throw new ArgumentException("This youtube video already is in the database.");

            var newVideo = _videoRepository.Add(videoEntity);

            var videoResponse = VideoMapper.Mapper.Map<VideoResponse>(newVideo);
            return videoResponse;
        }
    }
}
