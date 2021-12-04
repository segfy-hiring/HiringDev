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
    public class GetAllVideoHandler : IRequestHandler<GetAllVideoRequest, PaginatedVideoResponse>
    {
        private readonly IVideoRepository _videoRepository;
        public GetAllVideoHandler(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }
        public async Task<PaginatedVideoResponse> Handle(GetAllVideoRequest request, CancellationToken cancellationToken)
        {
            var response = new PaginatedVideoResponse
            {
                Page = request.Page,
                PageSize = request.PageSize,
            };

            var videos = await _videoRepository.GetAllAsync();

            var paginated = videos.Skip((request.Page - 1) * request.PageSize).Take(request.PageSize);

            foreach(var video in paginated)
            {
                response.Videos.Add(VideoMapper.Mapper.Map<VideoResponse>(video));
            }

            response.Total = videos.Count();

            return response;
        }
    }

}
