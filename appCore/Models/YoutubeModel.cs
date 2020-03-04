using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace appcore.Models
{
    public class YoutubeModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId _id {get; set;}
        
        public string Title {get; set;}
       
        public string Description { get; set; }

        public string Kind { get; set; }

        public DateTime PublishedAt { get; set; }

        public string ChannelTitle { get; set; }

        public string Thumbnail { get; set; }

        public DateTime SearchedAT { get; private set; } = DateTime.Now;
    }
}