using Google;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SkillTestSegfy.Infrastructure.Services.Youtube
{
    public class YoutubeApiService : IYoutubeApiService
    {
        public YoutubeApiService()
        {
            YoutubeService = new YouTubeService(new BaseClientService.Initializer
            {
                // main
                //ApiKey = Environment.GetEnvironmentVariable("YoutubeApiKeyMain"),
                //ApplicationName = Environment.GetEnvironmentVariable("YoutubeApiProjectMain"),

                // alt
                ApiKey = Environment.GetEnvironmentVariable("YoutubeApiKeyAlt"),
                ApplicationName = Environment.GetEnvironmentVariable("YoutubeApiProjectAlt"),
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
            catch (Exception e)
            {
                if (e is GoogleApiException apiException)
                {
                    if (apiException.Error.Message.Contains("The request cannot be completed because you have exceeded your"))
                    {
                        return new YoutubeSearchResponse(false, null, "A chave de API do YouTube excedeu a cota de uso diário. Não é possível realizar mais pesquisas.");
                    }
                    else if (apiException.Error.Message.Contains("API key expired"))
                    {
                        return new YoutubeSearchResponse(false, null, "A chave de API do YouTube é inválida. Não é possível realizar pesquisas.");
                    }
                }

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
