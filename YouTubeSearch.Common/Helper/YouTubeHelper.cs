using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;

namespace YoutTubeSearch.API.Helpers
{
    public static class YouTubeHelper
    {
        private static string _apiKey = "AIzaSyDamjOWLsmUVxZnMBy4dzrt106axuoA0-I";
        public static async Task<SearchListResponse> Search(string name, string type, int pageSize = 500)
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = _apiKey
            });

            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = name;

            if (!string.IsNullOrEmpty(type))
            {
                searchListRequest.Type = type;
            }

            searchListRequest.MaxResults = pageSize;
            searchListRequest.Order = SearchResource.ListRequest.OrderEnum.Relevance;

            var searchListResponse = await searchListRequest.ExecuteAsync();

            return searchListResponse;
        }

        public static async Task<VideoListResponse> GetVideoById(string id)
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = _apiKey
            });

            var searchListRequest = youtubeService.Videos.List("snippet");
            searchListRequest.Id = id;


            var searchListResponse = await searchListRequest.ExecuteAsync();

            return searchListResponse;
        }

        public static async Task<ChannelListResponse> GetChannelById(string id)
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = _apiKey
            });

            var searchListRequest = youtubeService.Channels.List("snippet");
            searchListRequest.Id = id;


            var searchListResponse = await searchListRequest.ExecuteAsync();

            return searchListResponse;
        }
    }
}
