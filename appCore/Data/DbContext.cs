using System.Linq;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace appcore.Data
{
    public class DbContext
    {
        private IConfiguration _configuration;

         public DbContext(IConfiguration config)
        {
            _configuration = config;
        }

        public T ObterItem<T>(string id) {
            
        var client = new MongoClient("mongodb+srv://luketad2:<password>@cluster0-nqmn2.mongodb.net/test?retryWrites=true&w=majority");
        var database = client.GetDatabase("youtube");
        var filter = Builders<T>.Filter.Eq("_id", "5e5f01ab1c9d440000ca64de");
        return database.GetCollection<T>("youtube")
                            .Find(filter).FirstOrDefault();
        }
    }
}