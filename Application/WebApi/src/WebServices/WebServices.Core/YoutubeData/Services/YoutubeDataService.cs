namespace WebServices.Core.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Domain.Models;
    using Domain.Repositories;
    using Domain.Services;
    using Google.Apis.Services;
    using Google.Apis.YouTube.v3;
    using Infra.Services.Core;
    using WebServices.Domain.Util;
    using WebServices.Domain.YoutubeData.Enums;

    /// <summary>
    /// Service of the <see cref="IYoutubeData"/> class.
    /// </summary>
    public class YoutubeDataService : BaseDataService<YoutubeData, long, IYoutubeDataRepository>, IYoutubeDataService
    {
        private readonly string apiKey = AppSettingsUtil.GetStringValue("YoutubeApi:Key");
        private readonly string project = AppSettingsUtil.GetStringValue("YoutubeApi:Project");
        private readonly int defaultPageSize = 50;

        /// <summary>
        /// Initializes a new instance of the <see cref="YoutubeDataService"/> class.
        /// </summary>
        /// <param name="objYoutubeDataRepository">IYoutubeDataRepository.</param>
        public YoutubeDataService(IYoutubeDataRepository objYoutubeDataRepository)
            : base(objYoutubeDataRepository)
        {
        }

        /// <summary>
        /// Search and Get Youtube Results.
        /// </summary>
        /// <param name="keyword">word to be searached.</param>
        /// <param name="searchType">type of search.</param>
        /// <param name="pageToken">Page token.</param>
        /// <returns>Youtube object with pages and items list.</returns>
        public Youtube Search(string keyword, YoutubeSearchType searchType, string pageToken)
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = apiKey,
                ApplicationName = project
            });

            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = keyword;
            searchListRequest.Type = searchType.ToString().ToLower();
            searchListRequest.MaxResults = defaultPageSize;

            if (!string.IsNullOrEmpty(pageToken))
            {
                searchListRequest.PageToken = pageToken;
            }

            // Call the search.list method to retrieve results matching the specified query term.
            var searchListResponse = searchListRequest.ExecuteAsync().Result;

            List<YoutubeData> items = new List<YoutubeData>();

            Youtube youtubeResult = new Youtube();
            youtubeResult.PreviousPage = searchListResponse.PrevPageToken;
            youtubeResult.NextPage = searchListResponse.NextPageToken;

            // Add each result to the appropriate list, and then display the lists of
            // matching videos, channels, and playlists.
            foreach (var searchResult in searchListResponse.Items)
            {
                YoutubeData youtubeData = new YoutubeData();
                youtubeData.ChannelId = searchResult.Snippet.ChannelId;
                youtubeData.Title = searchResult.Snippet.Title;
                youtubeData.PublishedAt = searchResult.Snippet.PublishedAt;
                youtubeData.ThumbnailUrl = searchResult.Snippet.Thumbnails.Medium.Url;
                youtubeData.ChannelTitle = searchResult.Snippet.ChannelTitle;

                switch (searchResult.Id.Kind)
                {
                    case "youtube#video":
                        youtubeData.VideoId = searchResult.Id.VideoId;
                        youtubeData.Type = (int)YoutubeSearchType.Video;

                        // If video doesn't exist, save the object in database
                        var existVideo = ObjServiceRepository.GetAllNoTracking().Where(x => x.VideoId == youtubeData.VideoId).FirstOrDefault();

                        if (existVideo == null)
                        {
                            ObjServiceRepository.Insert(youtubeData);
                            ObjServiceRepository.SaveChanges();
                        }

                        break;

                    case "youtube#channel":
                        youtubeData.ChannelId = searchResult.Snippet.ChannelId;
                        youtubeData.Title = searchResult.Snippet.Title;
                        youtubeData.Type = (int)YoutubeSearchType.Channel;

                        // If channel doesn't exist, save the object in database
                        var existChannel = ObjServiceRepository.GetAllNoTracking().Where(x => x.ChannelId == youtubeData.ChannelId).FirstOrDefault();

                        if (existChannel == null)
                        {
                            ObjServiceRepository.Insert(youtubeData);
                            ObjServiceRepository.SaveChanges();
                        }

                        break;
                }

                items.Add(youtubeData);
            }

            // Add items to the list
            youtubeResult.YoutubeData = items;

            return youtubeResult;
        }

        /// <summary>
        /// Get video details.
        /// </summary>
        /// <param name="videoId">youtube id video.</param>
        /// <returns>YoutubeDataDetail video detail.</returns>
        public YoutubeDataDetail GetVideoDetail(string videoId)
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = apiKey,
                ApplicationName = project
            });

            var searchListRequest = youtubeService.Videos.List("snippet,player, statistics");
            searchListRequest.Id = videoId;
            searchListRequest.MaxResults = 1;

            // Call the search.list method to retrieve results matching the specified query term.
            var searchListResponse = searchListRequest.ExecuteAsync().Result;

            var searchResult = searchListResponse.Items[0];

            YoutubeDataDetail video = new YoutubeDataDetail();
            video.EmbedHtml = searchResult.Player.EmbedHtml;
            video.LikeCount = (long)searchResult.Statistics.LikeCount;
            video.DislikeCount = (long)searchResult.Statistics.DislikeCount;
            video.ViewCount = (long)searchResult.Statistics.ViewCount;
            video.Type = (int)YoutubeSearchType.Video;

            return video;
        }

        /// <summary>
        /// Get channel details.
        /// </summary>
        /// <param name="channelId">youtube id channel.</param>
        /// <returns>YoutubeDataDetail video detail.</returns>
        public YoutubeDataDetail GetChannelDetail(string channelId)
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                // Remove this tag before checkin
                ApiKey = apiKey,
                ApplicationName = project
            });

            var searchListRequest = youtubeService.Channels.List("snippet,statistics");
            searchListRequest.Id = channelId;
            searchListRequest.MaxResults = 1;

            // Call the search.list method to retrieve results matching the specified query term.
            var searchListResponse = searchListRequest.ExecuteAsync().Result;

            var searchResult = searchListResponse.Items[0];

            YoutubeDataDetail video = new YoutubeDataDetail();
            video.VideoCount = (long)searchResult.Statistics.VideoCount;
            video.ViewCount = (long)searchResult.Statistics.ViewCount;
            video.SubscriberCount = (long)searchResult.Statistics.SubscriberCount;
            video.Type = (int)YoutubeSearchType.Channel;

            return video;
        }
    }
}