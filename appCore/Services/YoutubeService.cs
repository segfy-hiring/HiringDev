using appCore.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace appCore.Services
{
    public class YoutubeService
    {
        private readonly IMongoCollection<YoutubeModel> _ytlist;

        public YoutubeService(IYotubeDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _ytlist = database.GetCollection<YoutubeModel>(settings.YTCollectionName);
        }

        public List<YoutubeModel> Get() =>
            _ytlist.Find(yt => true).ToList();

        public YoutubeModel Get(string id) =>
            _ytlist.Find<YoutubeModel>(yt => yt.Id == id).FirstOrDefault();

        public YoutubeModel Create(YoutubeModel yt)
        {
            _ytlist.InsertOne(yt);
            return yt;
        }

        public void Update(string id, YoutubeModel ytIn) =>
            _ytlist.ReplaceOne(yt => yt.Id == id, ytIn);

        public void Remove(YoutubeModel ytIn) =>
            _ytlist.DeleteOne(yt => yt.Id == ytIn.Id);

        public void Remove(string id) => 
            _ytlist.DeleteOne(yt => yt.Id == id);
    }
}