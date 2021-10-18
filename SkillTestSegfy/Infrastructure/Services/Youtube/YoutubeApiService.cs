using Google;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using Microsoft.EntityFrameworkCore;
using SkillTestSegfy.Domain.Entities;
using SkillTestSegfy.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillTestSegfy.Infrastructure.Services.Youtube
{
    public class YoutubeApiService : IYoutubeApiService
    {
        public YoutubeApiService(DatabaseContext context)
        {
            DatabaseContext = context;
            YoutubeService = new YouTubeService(new BaseClientService.Initializer
            {
                ApiKey = ConfigManager.YoutubeApiKey,
                ApplicationName = ConfigManager.YoutubeApiProject,
            });
        }

        private DatabaseContext DatabaseContext { get; }
        private YouTubeService YoutubeService { get; }

        public async Task<YoutubeSearchResponse> Search(string term, int maxResults, YoutubeItemType? type)
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

                var utcNow = DateTime.UtcNow;
                var items = response.Items
                    .Select(o => new YoutubeItem(
                        utcNow,
                        GetYoutubeType(o.Id?.Kind),
                        GetYoutubeId(o.Id),
                        o.Snippet?.Title,
                        o.Snippet?.Description,
                        o.Snippet?.Thumbnails?.High?.Url
                    ))
                    .Where(IsValidItem)
                    .ToList();

                await SaveHistory(items);

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

        public async Task<IEnumerable<YoutubeItem>> GetHistory(string term, int maxResults, YoutubeItemType? type)
        {
            var repository = DatabaseContext.Set<YoutubeItem>();
            var query = repository.AsQueryable();

            term = term?.Trim();
            if (!string.IsNullOrEmpty(term))
            {
                query = query.Where(o => o.Title.Contains(term) || o.Description.Contains(term));
            }

            if (type != null)
            {
                query = query.Where(o => o.Type == type);
            }

            query = query
                .OrderByDescending(o => o.SearchDateTime)
                .Take(maxResults);

            var items = await query.ToListAsync();
            return items;
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
                && !string.IsNullOrEmpty(item.YoutubeId)
                && !string.IsNullOrEmpty(item.Title)
                && !string.IsNullOrEmpty(item.ThumbnailUrl);
        }

        private async Task SaveHistory(IEnumerable<YoutubeItem> items)
        {
            var repository = DatabaseContext.Set<YoutubeItem>();

            var toInsert = items.ToList();
            foreach (var item in items)
            {
                var existing = repository.FirstOrDefault(o => o.Type == item.Type && o.YoutubeId == item.YoutubeId);
                if (existing != null)
                {
                    toInsert.Remove(item);
                    existing.UpdateFrom(item);
                }
            }

            await repository.AddRangeAsync(toInsert);
            await DatabaseContext.SaveChangesAsync();
        }
    }
}
