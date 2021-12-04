using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeSearch.Application.Responses
{
    public class VideoResponse
    {
        public long Id { get; set; }
        public string YoutubeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Thumb { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime? LastUpdate { get; set; }
    }
}
