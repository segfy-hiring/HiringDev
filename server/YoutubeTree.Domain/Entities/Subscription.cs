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

        public string YoutubeId { get; private set; }
        public string Type { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime? PublishedAt { get; private set; }
        public string DefaultThumbnail { get; private set; }
        public string MediumThumbnail { get; private set; }
        public string HighThumbnail { get; private set; }
    }
}