using SkillTestSegfy.Domain.Entities;
using System.Collections.Generic;

namespace SkillTestSegfy.Infrastructure.Services.Youtube
{
    public class YoutubeSearchResponse
    {
        public YoutubeSearchResponse(bool success, IEnumerable<YoutubeItem> items, string error)
        {
            Success = success;
            Items = items;
            Error = error;
        }

        public bool Success { get; }
        public IEnumerable<YoutubeItem> Items { get; }
        public string Error { get; }
    }
}
