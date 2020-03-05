using appcore.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace appcore.Services
{
    public class YoutubeService
    {
        private readonly IMongoCollection<YoutubeModel> _ytlist;

        public YoutubeService(IYoutubeDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _ytlist = database.GetCollection<YoutubeModel>(settings.YTCollectionName);
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