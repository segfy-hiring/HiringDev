using System;

namespace SegFyChallenge.Domain.Models
{
    public class Channel
    {
        public int Id { get; set; }
        public string ChannelId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishedAt { get; set; }
    }
}