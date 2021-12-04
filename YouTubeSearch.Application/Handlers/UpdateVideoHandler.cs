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
    public class UpdateVideoHandler : IRequestHandler<UpdateVideoCommand, VideoResponse>
    {
        private readonly IVideoRepository _videoRepository;
        public UpdateVideoHandler(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }
        public async Task<VideoResponse> Handle(UpdateVideoCommand request, CancellationToken cancellationToken)
        {
            var video = await _videoRepository.GetByIdAsync(request.Id);

            if (video == null)
                throw new KeyNotFoundException("Video Not Found.");

            video.LastUpdated = DateTime.Now;
            video.Name = request.Name;
            video.Description = request.Description;
            video.Thumb = request.Thumb;

            video = _videoRepository.Update(video);

            var videoResponse = VideoMapper.Mapper.Map<VideoResponse>(video);
            return videoResponse;
        }
    }
}
