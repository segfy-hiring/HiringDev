using System;

namespace SegFyChallenge.Application.Dto
{
    public enum YoutubeItemKind
    {
        Video,
        Channel
    }

    public class YoutubeItem
    {
        public string VideoId { get; set; }
        public string ChannelId { get; set; }
        public YoutubeItemKind Kind { get; set; }
        public DateTime? PublishedAt { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}