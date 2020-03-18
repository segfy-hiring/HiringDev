using System;
using YoutubeAPI.Business.Enums;

namespace YoutubeApi.Api.Models
{
    [Serializable]
    public class SearchViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }

        public bool IsFavorite { get; set; }

        public SearchType Type { get; set; }
        public string Description { get; set; }
        public virtual DateTime? PublishedAt { get; set; }
    }
}
