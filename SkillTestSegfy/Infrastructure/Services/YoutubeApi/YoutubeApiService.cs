using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
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

        public async Task<YoutubeSearchResponse> Search(string term, long maxResults, YoutubeItemType? type)
        {
            try
            {
                var request = YoutubeService.Search.List("snippet");
                request.Q = term;
                request.MaxResults = maxResults;

                if (type == YoutubeItemType.Video)
                {
                    request.Type = "video";
                }
                else if (type == YoutubeItemType.Channel)
                {
                    request.Type = "channel";
                }
                else if (type == YoutubeItemType.Playlist)
                {
                    request.Type = "playlist";
                }

                var response = await request.ExecuteAsync();

                foreach (var item in response.Items)
                {
                    var t = item;
                }

                var items = response.Items
                    .Select(o => new YoutubeItem
                    {
                        Id = GetYoutubeId(o.Id),
                        Type = GetYoutubeType(o.Id?.Kind),
                        Title = o.Snippet?.Title,
                        Description = o.Snippet?.Description,
                        ThumbnailUrl = o.Snippet?.Thumbnails?.High?.Url,
                    })
                    .Where(IsValidItem)
                    .ToList();

                return new YoutubeSearchResponse(true, items, null);
            }
            catch
            {
                return new YoutubeSearchResponse(false, null, "Houve um erro inesperado na pesquisa. Por favor, tente novamente mais tarde.");
            }
        }

        private static string GetYoutubeId(ResourceId id)
        {
            return GetYoutubeType(id?.Kind) switch
            {
                YoutubeItemType.Video => id.VideoId,
                YoutubeItemType.Channel => id.ChannelId,
                YoutubeItemType.Playlist => id.PlaylistId,
                _ => null,
            };
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

        private static bool IsValidItem(YoutubeItem item)
        {
            return item.Type != YoutubeItemType.Unknown
                && !string.IsNullOrEmpty(item.Id)
                && !string.IsNullOrEmpty(item.Title)
                && !string.IsNullOrEmpty(item.ThumbnailUrl);
        }
    }
}
