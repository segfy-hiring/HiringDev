using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Joao.HiringDev.Servicos.Servicos
{
    public class YoutubeApiServico
    {
        public async Task Obter()
        {

            var youTubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyDJZG8ti1wfsoORJeBPHSbRKOFM1Q2nw-U",
                ApplicationName = this.GetType().ToString()
            });

            SearchResource.ListRequest listRequest = youTubeService.Search.List("snippet");
            listRequest.Q = "joão carias";
            listRequest.MaxResults = 50;

            var listResponse = await listRequest.ExecuteAsync();
            List<string> videos = new List<string>();
            List<string> canais = new List<string>();

            foreach (var item in listResponse.Items)
            {
                switch (item.Id.Kind)
                {
                    case "youtube#video":
                        videos.Add(String.Format("{0} ({1})", item.Snippet.Title, item.Id.VideoId));
                        break;

                    case "youtube#channel":
                        canais.Add(String.Format("{0} ({1})", item.Snippet.Title, item.Id.ChannelId));
                        break;
                }
            }
        }
    }
}
