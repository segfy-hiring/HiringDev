using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using appcore.Models.Result;

namespace appcore.Models
{
    public class YoutubeModel
    {
       
        public YoutubeModel()
        {

        }

        public YoutubeModel(Item item)
        {
            Kind = item.id.kind;

            switch (Kind)
            {
                case "youtube#video":
                    _id = item.id.videoId;
                    break;
                case "youtube#channel":
                    _id = item.id.channelId;
                    break;
                case "youtube#playlist":
                    _id = item.id.playlistId;
                    break;
            }

            Title = item.snippet.title;
            Description = item.snippet.description;
            PublishedAt = item.snippet.publishedAt;
            ChannelTitle = item.snippet.channelTitle;
            Thumbnail = item.snippet.thumbnails.medium.url;
        }

        [BsonId]
        
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