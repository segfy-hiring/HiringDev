using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeSearch.Application.Responses
{
    public class ChannelResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }
        public string YouTubeId { get; set; }
        public DateTime DateUploaded { get; set; }
    }
}
