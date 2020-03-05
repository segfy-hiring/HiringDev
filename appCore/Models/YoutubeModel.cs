using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace appcore.Models
{
    public class YoutubeModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id {get; set;}
        
        public string Title {get; set;}
       
        public string Description { get; set; }

        public string Kind { get; set; }

        [BsonRepresentation(BsonType.Document)]
        public DateTime PublishedAt { get; set; }

        public string ChannelTitle { get; set; }

        public string Thumbnail { get; set; }

        [BsonRepresentation(BsonType.Document)]
        public DateTime SearchedAT { get; private set; }
    }
}