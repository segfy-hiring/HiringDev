using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using System;
using System.Collections.Generic;

namespace AppYoutube.Models
{
    public class Development
    {
        /// <summary>
        /// chamada do método principal, passando uma palavra e 
        /// recebendo a lista de resultados
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public List<SearchResult> DadosYoutTube(string word)
        {
            try
            {
                return Run(word);
            }
            catch (AggregateException ex)
            {
                foreach (var e in ex.InnerExceptions)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
                return new List<SearchResult>();
            }
        }

        /// <summary>
        /// Através da API do google que se encontra disponível no nugget
        /// realiza uma conexão e busca um conteudo no youtube de acordo com
        /// o que for digitado
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public List<SearchResult> Run(string word)
        {
            var lista = new List<SearchResult>();
            var serviceYoutube = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "",
                ApplicationName = this.GetType().ToString()
            });
            var searchListRequest = serviceYoutube.Search.List("snippet");
            searchListRequest.Q = word;
            searchListRequest.MaxResults = 20;
            var searchListResponse = searchListRequest.Execute();
            foreach (var searchResult in searchListResponse.Items) { switch (searchResult.Id.Kind) { case "youtube#video": lista.Add(searchResult); break; } }
            return lista;
        }
    }
}
