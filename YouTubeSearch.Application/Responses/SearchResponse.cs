using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeSearch.Application.Responses
{
    public class SearchResponse
    {
        public long Id { get; set; }
        public string YoutubeId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? LastUpdate { get; set; }
    }
}
