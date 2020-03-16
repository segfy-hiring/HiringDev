using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using HiringDevWebAPI.Models;
using HiringDevWebAPI.Repositorio;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiringDevWebAPI.Services
{
    /// <summary>
    /// Classe principal <c>YoutubeService</c>.
    /// Contem os metodos das ações que sã opertinentes ao Youtube.
    /// Classe implementa interface IYoutubeService.
    /// </summary>
    public class YoutubeService : IYoutubeService
    {
        /// <summary>
        /// Representa um conjunto de propriedades de configuração da aplicação.
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Representa o repositório de dados do tipo YoutubeCanal.
        /// </summary>
        private readonly IYoutubeCanalRepositorio _youtubeCanalRepositorio;

        /// <summary>
        /// Representa o repositório de dados do tipo YoutubeVideo.
        /// </summary>
        private readonly IYoutubeVideoRepositorio _youtubeVideoRepositorio;

        /// <summary>
        /// Construtor para instancias do tipo <see cref="=YoutubeService"/>.
        /// </summary>
        /// <param name="configuration">Resolução de depencias da interface IConfiguration.</param>
        /// <param name="youtubeCanalRepositorio">Resolução de depencias da interface IYoutubeCanalRepositorio.</param>
        /// <param name="youtubeVideoRepositorio">Resolução de depencias da interface IYoutubeVideoRepositorio.</param>
        public YoutubeService(
            IConfiguration configuration,
            IYoutubeCanalRepositorio youtubeCanalRepositorio,
            IYoutubeVideoRepositorio youtubeVideoRepositorio)
        {
            _configuration = configuration;
            _youtubeVideoRepositorio = youtubeVideoRepositorio;
            _youtubeCanalRepositorio = youtubeCanalRepositorio;
        }

        /// <summary>
        /// Obtem uma lista objeto do tipo YoutubeEntidade, pesquisado por texto e tipo (video ou canal)
        /// na API do YouTube. Se Quota diária de requisições da API do YouTube for atingida, pesquisa será feita no banco de dados.
        /// </summary>
        /// <param name="texto">Texto a ser pesquisado.</param>
        /// <param name="tipo">Tipo a ser pesado tipo (video ou canal).</param>
        /// <returns>Lista de objetos do tipo YoutubeEntidade.</returns>
        public async Task<List<YoutubeEntidade>> PesquisarPorTextoETipo(string texto, string tipo)
        {
            //Obtem o valor das credenciais necessárias para a chamada da API do YouTube.
            var crendenciaisYouTube = _configuration.GetSection("CrendenciaisYouTube");

            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = crendenciaisYouTube["Chave"],
                ApplicationName = crendenciaisYouTube["Aplicacao"]
            });

            var searchResource = youtubeService.Search.List("snippet");

            searchResource.Order = SearchResource.ListRequest.OrderEnum.Relevance;
            searchResource.Q = texto;
            searchResource.RegionCode = "BR";
            searchResource.MaxResults = 50;
            searchResource.Type = tipo;

            List<YoutubeEntidade> listaResultado = new List<YoutubeEntidade>();

            try
            {
                //Executa pesquisa na API do YouTube.
                var resultado = await searchResource.ExecuteAsync();

                foreach (var item in resultado.Items)
                {
                    switch (tipo.ToLower())
                    {
                        case "channel":

                            YoutubeCanal youtubeCanal = new YoutubeCanal(item);

                            AtualizarInserirYoutubeCanal(youtubeCanal);

                            listaResultado.Add(youtubeCanal);

                            break;

                        case "video":

                            YoutubeVideo youtubeVideo = new YoutubeVideo(item);

                            AtualizarInserirYoutubeVideo(youtubeVideo);

                            listaResultado.Add(new YoutubeVideo(item));

                            break;

                        default:
                            break;
                    }
                }
            }
            //Caso a quota diária de requisições da API do YouTube seja atingida,
            //as pesquisa devem ser feitas com os dados já inseridos no banco de dados.
            catch (Exception)
            {
                switch (tipo.ToLower())
                {
                    case "channel":

                        listaResultado.AddRange(_youtubeCanalRepositorio.ObterListaCanaisPorTexto(texto));

                        break;

                    case "video":

                        listaResultado.AddRange(_youtubeVideoRepositorio.ObterListaVideosPorTexto(texto));

                        break;

                    default:
                        break;
                }
            }

            return listaResultado;
        }

        /// <summary>
        /// Atualiza ou insere uma entidade do tipo YoutubeCanal no banco de dados.
        /// </summary>
        /// <param name="youtubeCanal">Objeto a ser atualizado ou inserido.</param>
        private void AtualizarInserirYoutubeCanal(YoutubeCanal youtubeCanal)
        {
            if (_youtubeCanalRepositorio.ObterYoutubeCanalPorId(youtubeCanal.CanalId) != null)
            {
                _youtubeCanalRepositorio.AtualizarYoutubeCanal(youtubeCanal);
            }
            else
            {
                _youtubeCanalRepositorio.InserirYoutubeCanal(youtubeCanal);
            }
        }

        /// <summary>
        /// Atualiza ou insere uma entidade do tipo YoutubeVideo no banco de dados.
        /// </summary>
        /// <param name="youtubeVideo">Objeto a ser atualizado ou inserido.</param>
        private void AtualizarInserirYoutubeVideo(YoutubeVideo youtubeVideo)
        {
            if (_youtubeVideoRepositorio.ObterYoutubeVideoPorId(youtubeVideo.VideoId) != null)
            {
                _youtubeVideoRepositorio.AtualizarYoutubeVideo(youtubeVideo);
            }
            else
            {
                _youtubeVideoRepositorio.InserirYoutubeVideo(youtubeVideo);
            }
        }
    }
}