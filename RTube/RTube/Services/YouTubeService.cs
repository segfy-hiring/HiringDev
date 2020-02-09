using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RTube.Models;
using RTube.Models.Pagination;
using RTube.Models.Result;
using RTube.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using static RTube.Models.Pagination.SearchHistoryExtensions;

namespace RTube.Services
{
    public class YouTubeService : IYouTubeService
    {
        private readonly IConfiguration _configuration;
        private readonly IYouTubeRepository _repository;

        public YouTubeService(IConfiguration configuration, IYouTubeRepository repository)
        {
            _configuration = configuration;
            _repository = repository;
        }

        public PagedSearchHistory GetSearchHistory(SearchHistoryPagination pagination)
        {
            return _repository.List()
                .ToPagedSearchHistory(pagination);
        }

        public async Task<YouTubeResult> Search(string query, string pageToken = null)
        { 
            var client = new HttpClient();

            var section = _configuration.GetSection("Credentials:YouTube");

            var key = section["key"];
            var baseUrl = section["baseUrl"];

            var url = $@"{baseUrl}search?part=id%2Csnippet&q={query}&pageToken={pageToken}&key={key}";

            var httpResponse = await client.GetAsync(url);

            if (!httpResponse.IsSuccessStatusCode)
                throw new Exception("Cannot retrieve api data");

            var content = await httpResponse.Content.ReadAsStringAsync();
            var apiResult = JsonConvert.DeserializeObject<YouTubeApiResult>(content);

            var result = new YouTubeResult(apiResult);

            SaveOrUpdateItens(result.Items);

            return result;
        }

        private void SaveOrUpdateItens(IEnumerable<YouTubeItem> items)
        {
            foreach(var item in items)
            {
                if (_repository.Exists(item))
                    _repository.Update(item);
                else
                    _repository.Save(item);
            }
        }
    }
}
