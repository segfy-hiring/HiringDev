using System;
using RTube.Models.Result;

namespace RTube.Models
{
    public class YouTubeItem
    {
        public YouTubeItem()
        {

        }

        public YouTubeItem(Item item)
        {
            Kind = item.id.kind;

            switch (Kind)
            {
                case "youtube#video":
                    Id = item.id.videoId;
                    break;
                case "youtube#channel":
                    Id = item.id.channelId;
                    break;
                case "youtube#playlist":
                    Id = item.id.playlistId;
                    break;
            }

            Title = item.snippet.title;
            Description = item.snippet.description;
            PublishedAt = item.snippet.publishedAt;
            ChannelTitle = item.snippet.channelTitle;
            Thumbnail = item.snippet.thumbnails.medium.url;
        }


        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Kind { get; set; }

        public DateTime PublishedAt { get; set; }

        public string ChannelTitle { get; set; }

        public string Thumbnail { get; set; }
    }
}
