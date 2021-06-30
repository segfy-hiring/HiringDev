using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using YoutubeApiConsumerApp.Models;

namespace YoutubeApiConsumerApp.Services.Youtube.Interfaces
{
    public interface IYoutubeAppService
    {      
        YouTubeService InitializeYoutubeService();
        SearchListResponse GetVideosAndChannelsBySearchTerm(SearchModel searchViewModel);
        SearchResponseModel FromYoutubeResponseToSearchResponseModel(SearchListResponse searchListResponse);
    }
}
