using appcore.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using appcore.Models.Result;

namespace appcore.Services
{
    public class YoutubeService
    {
        private readonly IMongoCollection<YoutubeModel> _ytlist;
        private readonly IConfiguration _configuration;


        public YoutubeService(IYoutubeDatabaseSettings settings, IConfiguration configuration)
        {

            _configuration = configuration;

            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _ytlist = database.GetCollection<YoutubeModel>(settings.YTCollectionName);
        }

        public async Task<YTResult> Search(string query) {
            var cliente = new HttpClient();
            var clienteAuth = _configuration.GetSection("YoutubeCrendetials");
            
            var key = clienteAuth["key"];
            var baseUrl = clienteAuth["baseUrl"];
            
            var url = $@"{baseUrl}search?part=snippet&q={query}&key={key}";
            var httpResponse = await cliente.GetAsync(url);

            var content = await httpResponse.Content.ReadAsStringAsync();
            var apiResult = JsonConvert.DeserializeObject<YTResultAPI>(content);

            var result = new YTResult(apiResult);

            YTResulToMongo(result.Items);
            
            return result;
        }

        private void YTResulToMongo (IEnumerable<YoutubeModel> items)
        {
            foreach (var item in items)
            {
                if (Get(item._id))
                {
                    Update(item._id, item);
                } else
                {
                    Create(item);
                }
            }
        }

        public List<YoutubeModel> Get() =>
            _ytlist.Find(yt => true).ToList();

        public bool Get(string id)
        {
            //YoutubeModel x = _ytlist.Find<YoutubeModel>(yt => yt._id == id).FirstOrDefault();
            //var x = _ytlist.Find(
            //  Builders<YoutubeModel>.Filter.Exists(m => m._id, true));
            var x = _ytlist.Find<YoutubeModel>(yt => yt._id == id).FirstOrDefault();

            return x != null ?  true : false;
        }


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