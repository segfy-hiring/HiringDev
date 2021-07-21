using Google.Apis.Samples.Helper;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;

using Joao.HiringDev.Servicos.Core.IServicos;

namespace Joao.HiringDev.Servicos.Servicos
{
    public class YoutubeApiServico : IYoutubeApiServico
    {
        public void Pesquisar()
        {
            YoutubeService youtube = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = ""
            });

            SearchResource.ListRequest listRequest = youtube.Search.List("snippet");
            listRequest.Q = CommandLine.RequestUserInput<string>("Search term: ");
            listRequest.Order = SearchResource.Order.Relevance;

            SearchListResponse searchResponse = listRequest.Fetch();
        }
    }
}
