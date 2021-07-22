using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Joao.HiringDev.Dominio.Entidades;
using Joao.HiringDev.Servicos.Core.IServicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Joao.HiringDev.Servicos.Servicos
{
    public class YoutubeApiServico : IYoutubeApiServico
    {
        public async Task Obter(string busca)
        {

            var youTubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyDJZG8ti1wfsoORJeBPHSbRKOFM1Q2nw-U",
                ApplicationName = this.GetType().ToString()
            });

            SearchResource.ListRequest listRequest = youTubeService.Search.List("snippet");
            listRequest.Q = busca;
            listRequest.MaxResults = 50;

            var listResponse = await listRequest.ExecuteAsync();
            List<VideoYoutube> videos = new List<VideoYoutube>();
            List<CanalYoutube> canais = new List<CanalYoutube>();

            foreach (var item in listResponse.Items)
            {
                switch (item.Id.Kind)
                {
                    case "youtube#video":
                        
                        videos.Add(new VideoYoutube(item.Id.VideoId, item.Snippet.Title));
                        break;

                    case "youtube#channel":
                        canais.Add(new CanalYoutube(item.Id.ChannelId, item.Snippet.Title));
                        break;
                }
            }
        }
    }
}
