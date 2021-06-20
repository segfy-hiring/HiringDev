using System;

namespace SegFyChallenge.Presentation.Models
{
    public class ChannelViewModel
    {
        public int Id { get; set; }
        public string ChannelId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishedAt { get; set; }
    }
}