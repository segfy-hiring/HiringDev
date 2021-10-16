using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillTestSegfy.Infrastructure.Services.YoutubeApi
{
    public class YoutubeApiService : IYoutubeApiService
    {
        private const string ApiKey = "AIzaSyBQEHRxdlcLP-tMjidzf4DE8uptV5VvFaA";
        private const string ApplicationName = "SkillTestSegfy";

        public YoutubeApiService()
        {
            YoutubeService = new YouTubeService(new BaseClientService.Initializer
            {
                ApiKey = ApiKey,
                ApplicationName = ApplicationName,
            });
        }

        private YouTubeService YoutubeService { get; }

        public async Task<IEnumerable<YoutubeItem>> Search(string term)
        {
            var request = YoutubeService.Search.List("snippet");
            request.Q = term;
            request.MaxResults = 20;

            var response = await request.ExecuteAsync();

            foreach (var item in response.Items)
            {
                var t = item;
            }

            var items = response.Items
                .Select(o => new YoutubeItem
                {
                    Id = GetYoutubeId(o.Id),
                    Type = GetYoutubeType(o.Id.Kind),
                    Title = o.Snippet?.Title,
                    Description = o.Snippet?.Description,
                    ThumbnailUrl = o.Snippet?.Thumbnails?.High?.Url,
                })
                .Where(o => o.Type != YoutubeItemType.Unknown)
                .ToList();

            return items;
        }

        private static YoutubeItemType GetYoutubeType(string kind)
        {
            return kind switch
            {
                "youtube#video" => YoutubeItemType.Video,
                "youtube#channel" => YoutubeItemType.Channel,
                "youtube#playlist" => YoutubeItemType.Playlist,
                _ => YoutubeItemType.Unknown,
            };
        }

        private static string GetYoutubeId(ResourceId id)
        {
            return GetYoutubeType(id.Kind) switch
            {
                YoutubeItemType.Video => id.VideoId,
                YoutubeItemType.Channel => id.ChannelId,
                YoutubeItemType.Playlist => id.PlaylistId,
                _ => null,
            };
        }
    }
}
