using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using RestSharp;
using SegFyChallenge.Application.Dto;
using SegFyChallenge.Application.Interfaces.Infra;

namespace SegFyChallenge.Infra.External.YoutubeApi
{
    public class YoutubeApiClient : IYoutubeApiClient
    {
        private readonly YouTubeService _youtubeService;

        public YoutubeApiClient(string apiKey)
        {
            var init = new BaseClientService.Initializer()
            {
                ApiKey = apiKey,
                ApplicationName = this.GetType().ToString()
            };

            _youtubeService = new YouTubeService(init);
        }

        public async Task<List<YoutubeItem>> Search(string content, int maxResults, SearchType searchType)
        {
            List<YoutubeItem> youtubeItems = new List<YoutubeItem>();

            string searchTypeStr = string.Empty;
            switch (searchType)
            {
                case SearchType.Video:
                    searchTypeStr = "video";
                    break;
                case SearchType.Channel:
                    searchTypeStr = "channel";
                    break;
                case SearchType.Both:
                    searchTypeStr = "video,channel";
                    break;
            }

            var searchRequest = _youtubeService.Search.List("snippet");
            searchRequest.Q = content;
            searchRequest.MaxResults = maxResults;
            searchRequest.Type = searchTypeStr;

            var response = await searchRequest.ExecuteAsync();

            foreach (var item in response.Items)
            {
                youtubeItems.Add(new YoutubeItem{
                    Kind = item.Id.Kind == "youtube#video" ? YoutubeItemKind.Video : YoutubeItemKind.Channel,
                    ChannelId = item.Snippet.ChannelId,
                    Description = item.Snippet.Description,
                    Title = item.Snippet.Title,
                    PublishedAt = item.Snippet.PublishedAt,
                    VideoId = item.Id.Kind == "youtube#video" ? item.Id.VideoId : null
                });
            }

            return youtubeItems;
        }
    }
}