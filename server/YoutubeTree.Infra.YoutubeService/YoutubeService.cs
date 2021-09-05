using System.Collections.Generic;
using System.Threading.Tasks;
using Google.Apis.YouTube.v3;

namespace YoutubeTree.Infra.YoutubeService
{
    public class YoutubeService : IYoutubeService
    {
        private const short MAX_RESULTS = 10;
        private readonly YouTubeService _youtubeService;

        public YoutubeService(YouTubeService youtubeService)
        {
            _youtubeService = youtubeService;
        }

        public async Task<IEnumerable<YoutubeResponse>> Search(YoutubeRequest request)
        {
            var results = new List<YoutubeResponse>(MAX_RESULTS);            
            var listRequest = _youtubeService.Search.List("snippet");

            listRequest.Q = request.Term;
            listRequest.MaxResults = MAX_RESULTS;
            listRequest.Order = SearchResource.ListRequest.OrderEnum.Relevance;
            listRequest.PageToken = request.NextPageToken;

            var response = await listRequest.ExecuteAsync();

            foreach (var result in response.Items)
            {
                results.Add(
                    new YoutubeResponse(
                        YoutubeHelper.GetId(result.Id),
                        YoutubeHelper.GetRsourceType(result.Id),
                        result.Snippet.Title,
                        result.Snippet.Description,
                        result.Snippet.PublishedAt,
                        result.Snippet.Thumbnails.Default__.Url,
                        result.Snippet.Thumbnails.Medium.Url,
                        result.Snippet.Thumbnails.High.Url,
                        response.NextPageToken
                    )
                );
            }

            return results;
        }
    }
}