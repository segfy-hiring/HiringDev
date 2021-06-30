using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using System.Collections.Generic;
using YoutubeApiConsumerApp.Models;
using YoutubeApiConsumerApp.Services.Youtube.Interfaces;

namespace YoutubeApiConsumerApp.Services.Youtube
{
    public class YoutubeAppService : IYoutubeAppService
    {
        private readonly string YOUTUBE_APP_API_KEY = "{ACCESS_KEY}";

        public YoutubeAppService() { }

        public YouTubeService InitializeYoutubeService()
        {
            YouTubeService youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = YOUTUBE_APP_API_KEY
            });

            return youtubeService;
        }

        public SearchListResponse GetVideosAndChannelsBySearchTerm(SearchModel searchViewModel)
        {
            var youtubeService = InitializeYoutubeService();

            SearchResource.ListRequest listRequest = youtubeService.Search.List("snippet");
            listRequest.Q = searchViewModel.KeyWord;
            listRequest.Order = SearchResource.ListRequest.OrderEnum.Relevance;
            listRequest.MaxResults = 30;

            SearchListResponse searchListResponse = listRequest.Execute();

            return searchListResponse;
        }

        public SearchResponseModel FromYoutubeResponseToSearchResponseModel(SearchListResponse searchListResponse)
        {
            List<YoutubeVideoModel> returnedVideos = new List<YoutubeVideoModel>();
            List<YoutubeChannelModel> returnedChannels = new List<YoutubeChannelModel>();

            SearchResponseModel searchResponseModel = new SearchResponseModel(returnedVideos, returnedChannels);

            foreach (SearchResult searchResult in searchListResponse.Items)
            {
                switch (searchResult.Id.Kind)
                {
                    case "youtube#video":
                        YoutubeVideoModel youtubeVideoViewModel = new YoutubeVideoModel()
                        {
                            Id                     = searchResult.Snippet.ChannelId,
                            Title                  = searchResult.Snippet.Title,
                            Description            = searchResult.Snippet.Description,
                            ChannelId              = searchResult.Snippet.ChannelId,
                            ChannelTitle           = searchResult.Snippet.ChannelTitle,
                            PublishedAtRaw         = searchResult.Snippet.PublishedAtRaw,
                            LiveBroadcastContent   = searchResult.Snippet.LiveBroadcastContent,
                            ETag                   = searchResult.Snippet.ETag,
                            ThumbnailUrlVideoImage = searchResult.Snippet.Thumbnails.High.Url

                        };
                        searchResponseModel._youtubeVideos.Add(youtubeVideoViewModel);
                        break;
                    case "youtube#channel":
                        YoutubeChannelModel youtubeChannelViewModel = new YoutubeChannelModel()
                        {
                            Id                     = searchResult.Snippet.ChannelId,
                            Title                  = searchResult.Snippet.Title,
                            Description            = searchResult.Snippet.Description,
                            ChannelId              = searchResult.Snippet.ChannelId,
                            ChannelTitle           = searchResult.Snippet.ChannelTitle,
                            PublishedAtRaw         = searchResult.Snippet.PublishedAtRaw,
                            LiveBroadcastContent   = searchResult.Snippet.LiveBroadcastContent,
                            ETag                   = searchResult.Snippet.ETag,
                            ThumbnailUrlVideoImage = searchResult.Snippet.Thumbnails.High.Url
                        };
                        searchResponseModel._youtubeChannels.Add(youtubeChannelViewModel);
                        break;

                }
            }

            return searchResponseModel;
        }
       
    }
}
