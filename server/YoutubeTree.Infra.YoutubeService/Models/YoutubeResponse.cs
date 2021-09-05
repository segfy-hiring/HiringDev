using System;

namespace YoutubeTree.Infra.YoutubeService
{
    public class YoutubeResponse
    {
        public YoutubeResponse(
            string id,
            string type,
            string title,
            string description,
            DateTime? publishedAt,
            string defaultThumbnail,
            string mediumThumbnail,
            string highThumbnail,
            string nextPageToken)
        {
            Id = id;
            Type = type;
            Title = title;
            Description = description;
            PublishedAt = publishedAt;
            DefaultThumbnail = defaultThumbnail;
            MediumThumbnail = mediumThumbnail;
            HighThumbnail = highThumbnail;
            NextPageToken = nextPageToken;
        }

        public string Id { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? PublishedAt { get; set; }
        public string DefaultThumbnail { get; set; }
        public string MediumThumbnail { get; set; }
        public string HighThumbnail { get; set; }
        public string NextPageToken { get; set; }
    }
}