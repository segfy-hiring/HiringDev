using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace AppYoutube.Models
{
    public class DataService
    {
        private readonly IMongoCollection<Dados> _Dadoss;

        public DataService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _Dadoss = database.GetCollection<Dados>(settings.ApiCollectionName);
        }

        public List<Dados> Get()
        {
            return _Dadoss.Find(Dados => true).ToList();
        }

        public Dados Get(string id)
        {
            return _Dadoss.Find<Dados>(Dados => Dados.Id == id).FirstOrDefault();
        }

        public Dados Create(Dados Dados)
        {
            _Dadoss.InsertOne(Dados);
            return Dados;
        }

        public void Update(string id, Dados DadosIn)
        {
            _Dadoss.ReplaceOne(Dados => Dados.Id == id, DadosIn);
        }

        public void Remove(Dados DadosIn)
        {
            _Dadoss.DeleteOne(Dados => Dados.Id == DadosIn.Id);
        }

        public void Remove(string id)
        {
            _Dadoss.DeleteOne(Dados => Dados.Id == id);
        }
    }
}
