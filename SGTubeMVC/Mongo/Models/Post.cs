using MongoDB.Bson.Serialization.Attributes;
using System;

namespace SGTubeMVC.Mongo.Models
{
    public class Post
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        public string Title { get; set; }
        public DateTime data { get; set; }
    }
}
