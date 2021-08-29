using System;

namespace YoutubeTree.API
{
    public class SubscriptionRequest
    {
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