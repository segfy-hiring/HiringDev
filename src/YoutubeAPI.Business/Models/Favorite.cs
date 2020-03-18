using System;
using YoutubeAPI.Business.Enums;

namespace YoutubeAPI.Business.Models
{
    public class Favorite
    {
        public string Id { get; set; }
        public string Title { get; set; }

        public SearchType Type { get; set; }
        public string Description { get; set; }
        public DateTime? PublishedAt { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }

        public bool IsFavorite { get; set; }
    }
}
