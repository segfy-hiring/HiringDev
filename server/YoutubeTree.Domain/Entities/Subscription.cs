using System;
using YoutubeTree.Core;

namespace YoutubeTree.Domain
{
    public class Subscription : Entity
    {
        public Subscription(
            string youtubeId,
            string type,
            string title,
            string description,
            DateTime? publishedAt,
            string defaultThumbnail,
            string mediumThumbnail,
            string highThumbnail)
        {
            YoutubeId = youtubeId;
            Type = type;
            Title = title;
            Description = description;
            PublishedAt = publishedAt;
            DefaultThumbnail = defaultThumbnail;
            MediumThumbnail = mediumThumbnail;
            HighThumbnail = highThumbnail;
        }

        public string YoutubeId { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? PublishedAt { get; set; }
        public string DefaultThumbnail { get; set; }
        public string MediumThumbnail { get; set; }
        public string HighThumbnail { get; set; }
    }
}