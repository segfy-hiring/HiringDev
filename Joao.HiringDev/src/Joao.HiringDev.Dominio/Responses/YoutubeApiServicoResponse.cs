using Joao.HiringDev.Dominio.Core.Interfaces;
using Joao.HiringDev.Dominio.Entidades;
using System.Collections.Generic;

namespace Joao.HiringDev.Dominio.Responses
{
    public class YoutubeApiServicoResponse : IResponse
    {
        public YoutubeApiServicoResponse()
        {
            Videos = new List<VideoYoutube>();
            Canais = new List<CanalYoutube>();
        }

        public List<VideoYoutube> Videos { get; set; }
        public List<CanalYoutube> Canais { get; set; }
    }
}
