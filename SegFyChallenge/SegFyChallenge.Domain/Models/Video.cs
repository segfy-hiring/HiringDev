using System;

namespace SegFyChallenge.Domain.Models
{
    public class Video
    {
        public int Id { get; set; }
        public string VideoId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishedAt { get; set; }
        public string ChannelId { get; set; }
    }
}