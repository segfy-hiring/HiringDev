using MongoDB.Driver;
using SGTubeMVC.Mongo.Models;

namespace SGTubeMVC.Mongo
{
    public class Context
    {
        private readonly IMongoDatabase database;

        public Context()
        {
            database = new MongoClient("mongodb+srv://omnistack:omnistack@cluster0-dwaxa.mongodb.net/test?retryWrites=true&w=majority").GetDatabase("sgtube");
        }

        public IMongoCollection<Post> Posts
        {
            get
            {
                return database.GetCollection<Post>("sgtube");
            }
        }
    }
}
