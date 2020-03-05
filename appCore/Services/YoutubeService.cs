using appcore.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;


namespace appcore.Services
{
    public class YoutubeService
    {
        private readonly IMongoCollection<YoutubeModel> _ytlist;

        public YoutubeService(IYoutubeDatabaseSettings settings, IConfiguration configuration)
        {

            _configuration = configuration;

            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _ytlist = database.GetCollection<YoutubeModel>(settings.YTCollectionName);
        }

        public async Task<YoutubeModel> Search(string query) {
            var cliente = new HttpClient();
            var clienteAuth = _configuration.GetSection("YoutubeCrendetials");
            
            var key = clienteAuth["key"];
            var baseUrl = clienteAuth["baseUrl"];
            
            var url = $@"{baseUrl}search?part=id%2Csnippet&q={query}&pageToken=1&key={key}";
            var httpResponse = await cliente.GetAsync(url);

            var content = await httpResponse.Content.ReadAsStringAsync();
            var apiResult = JsonConvert.DeserializeObject<YoutubeModel>(content);

            var result = new YoutubeModel(apiResult);

            foreach (var item in result.Items) {
                if (Get(item.id)){
                    Update(item.id,item);
                } else {
                    InsertOne(item);
                }
            }
            
            return result;
        }

        public List<YoutubeModel> Get() =>
            _ytlist.Find(yt => true).ToList();

        public YoutubeModel Get(string id) =>
            _ytlist.Find<YoutubeModel>(yt => yt._id == id).FirstOrDefault();

        public YoutubeModel Create(YoutubeModel yt)
        {
            _ytlist.InsertOne(yt);
            return yt;
        }

        public void Update(string id, YoutubeModel ytIn) =>
            _ytlist.ReplaceOne(yt => yt._id == id, ytIn);

        public void Remove(YoutubeModel ytIn) =>
            _ytlist.DeleteOne(yt => yt._id == ytIn._id);

        public void Remove(string id) => 
            _ytlist.DeleteOne(yt => yt._id == id);
    }
}