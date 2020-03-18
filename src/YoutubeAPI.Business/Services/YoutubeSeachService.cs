using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using System.Linq;
using System.Threading.Tasks;
using YoutubeAPI.Business.Enums;
using YoutubeAPI.Business.Interfaces;
using YoutubeAPI.Business.Models;

namespace YoutubeAPI.Business.Services
{
    public class YoutubeSeachService : IYoutubeSeachService
    {
        private readonly YouTubeService service;
        private readonly IFavoriteRepository favoriteRepository;

        public YoutubeSeachService(YouTubeService service, IFavoriteRepository favoriteRepository)
        {
            this.service = service;
            this.favoriteRepository = favoriteRepository;
        }

        public async Task<Pagination> SeachAsync(string term, string nextPageToken = "")
        {
            var pagination = new Pagination();
            pagination.Search = term;
            SearchResource.ListRequest listRequest = service.Search.List("snippet");
            listRequest.Q = term;
            listRequest.Order = SearchResource.ListRequest.OrderEnum.Relevance;
            listRequest.MaxResults = 5;
            listRequest.PageToken = nextPageToken;

            SearchListResponse searchResponse = await listRequest.ExecuteAsync();

            foreach (SearchResult searchResult in searchResponse.Items)
            {
                pagination.NextPage = searchResponse.NextPageToken;

                var favorite = new Favorite();
                favorite.Title = searchResult.Snippet.Title;
                favorite.Description = searchResult.Snippet.Description;
                favorite.PublishedAt = searchResult.Snippet.PublishedAt;

                switch (searchResult.Id.Kind)
                {
                    case "youtube#video":
                        favorite.Type = SearchType.Video;
                        favorite.Id = searchResult.Id.VideoId;
                        break;

                    case "youtube#channel":
                        favorite.Type = SearchType.Channel;
                        favorite.Id = searchResult.Id.ChannelId;
                        break;

                    case "youtube#playlist":
                        favorite.Type = SearchType.Playlist;
                        favorite.Id = searchResult.Id.PlaylistId;

                        break;
                }


                pagination.Favorites.Add(favorite);
            }

            var allfavorites = await this.favoriteRepository.List(term);
            allfavorites.ForEach(x => x.IsFavorite = true);
            var favoritesIds = allfavorites.Select(x => x.Id);

            pagination.Favorites.RemoveAll(x => favoritesIds.Contains(x.Id));
            pagination.Favorites.AddRange(allfavorites);

            return pagination;
        }
    }
}
