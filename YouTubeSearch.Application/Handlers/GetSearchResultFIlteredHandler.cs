using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YoutTubeSearch.API.Helpers;
using YouTubeSearch.Application.Mappers;
using YouTubeSearch.Application.Queries;
using YouTubeSearch.Application.Responses;
using YouTubeSearch.Core.Repositories;

namespace YouTubeSearch.Application.Handlers
{
    public class GetSearchResultFIlteredHandler : IRequestHandler<GetSearchResultFilteredRequest, SearchPaginatedReponse>
    {
        private readonly IVideoRepository _videoRepository;
        private readonly IChannelRepository _channelRepository;
        public GetSearchResultFIlteredHandler(IVideoRepository videoRepository, IChannelRepository channelRepository)
        {
            _videoRepository = videoRepository;
            _channelRepository = channelRepository;
        }
        public async Task<SearchPaginatedReponse> Handle(GetSearchResultFilteredRequest request, CancellationToken cancellationToken)
        {
            var videosPaginated = new SearchPaginatedReponse();

            // Search for the videos/channels on youtube
            var youtubeResult = await YouTubeHelper.Search(request.Name, request.Type.HasValue ? request.Type.Value.ToString() : string.Empty);

            // Adds the result to the database
            foreach (var search in youtubeResult.Items)
            {
                if (!videosPaginated.Results.Any(s => s.Name == search.Snippet.Title))
                {
                    switch (search.Id.Kind)
                    {
                        case "youtube#video":
                            var video = _videoRepository.GetByName(search.Snippet.Title);

                            if (video == null)
                            {
                                // Get the details of the video to get the complete description
                                var videoDetails = await YouTubeHelper.GetVideoById(search.Id.VideoId);

                                video = _videoRepository.Add(new Core.Entities.Video
                                {
                                    Name = videoDetails.Items.First().Snippet.Title,
                                    ChannelId = search.Snippet.ChannelId,
                                    DateCreated = DateTime.Now,
                                    Description = videoDetails.Items.First().Snippet.Description,
                                    PublishDate = search.Snippet.PublishedAt.Value,
                                    Thumb = search.Snippet.Thumbnails.High.Url,
                                    YoutubeId = search.Id.VideoId
                                });
                            }

                            break;

                        case "youtube#channel":
                            var channel = _channelRepository.GetByName(search.Snippet.Title);

                            if (channel == null)
                            {
                                var channelDetails = await YouTubeHelper.GetChannelById(search.Id.ChannelId);

                                channel = _channelRepository.Add(new Core.Entities.Channel
                                {
                                    Name = search.Snippet.Title,
                                    DateCreated = DateTime.Now,
                                    Description = channelDetails.Items.First().Snippet.Description,
                                    DateUploaded = search.Snippet.PublishedAt.Value,
                                    Thumbnail = search.Snippet.Thumbnails.High.Url,
                                    YoutubeId = search.Id.ChannelId,
                                });
                            }

                            break;
                    }
                }
            }

            // Gets the data from the database
            if (!request.Type.HasValue || request.Type.Value == Common.Enum.TypeEnum.Video)
            {
                var videos = _videoRepository.GetContainsByName(request.Name);

                foreach (var video in videos)
                {
                    videosPaginated.Results.Add(new SearchResponse
                    {
                        DateCreated = video.PublishDate,
                        Id = video.Id,
                        LastUpdate = video.LastUpdated,
                        Name = video.Name,
                        YoutubeId = video.YoutubeId,
                        Type = "VIDEO"
                    });
                }
            }

            // Gets the data from the database
            if (!request.Type.HasValue || request.Type.Value == Common.Enum.TypeEnum.Channel)
            {
                var channels = _channelRepository.GetContainsByName(request.Name);

                foreach (var channel in channels)
                {
                    videosPaginated.Results.Add(new SearchResponse
                    {
                        DateCreated = channel.DateCreated,
                        Id = channel.Id,
                        LastUpdate = channel.LastUpdated,
                        Name = channel.Name,
                        YoutubeId = channel.YoutubeId,
                        Type = "CHANNEL"
                    });
                }
            }

            videosPaginated.Total = videosPaginated.Results.Count();
            videosPaginated.Page = request.Page;
            videosPaginated.PageSize = request.PageSize;

            videosPaginated.Results = videosPaginated.Results.Skip((request.Page - 1) * request.PageSize).Take(request.PageSize).ToList();

            return videosPaginated;
        }
    }
}
