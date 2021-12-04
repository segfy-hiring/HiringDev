using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YouTubeSearch.Application.Mappers;
using YouTubeSearch.Application.Queries;
using YouTubeSearch.Application.Responses;
using YouTubeSearch.Core.Entities;
using YouTubeSearch.Core.Repositories;

namespace YouTubeSearch.Application.Handlers
{
    public class GetVideoByIdHandler : IRequestHandler<GetVideoByIdRequest, VideoResponse>
    {
        private readonly IVideoRepository _videoRepository;
        public GetVideoByIdHandler(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }
        public async Task<VideoResponse> Handle(GetVideoByIdRequest request, CancellationToken cancellationToken)
        {
            var video = await _videoRepository.GetByIdAsync(request.Id);

            if (video == null)
                throw new KeyNotFoundException("Video not found.");

            return VideoMapper.Mapper.Map<VideoResponse>(video);
        }
    }

}
