using System.Threading.Tasks;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;

namespace SGTubeMVC.Youtube
{
  public class Search : ISearch
  {
    public async Task<SearchListResponse> YoutubeApi_Search(string termo)
    {
      var youtubeService = new YouTubeService(new BaseClientService.Initializer()
      {
        ApiKey = "AIzaSyD8O7xDBeQuWuR26DxRCTpNexfTRq-Wk9g",
        ApplicationName = this.GetType().ToString()
      });

      var searchListRequest = youtubeService.Search.List("snippet");
      searchListRequest.Q = termo;
      searchListRequest.MaxResults = 50;

      return await searchListRequest.ExecuteAsync();
      }
    }
  }
