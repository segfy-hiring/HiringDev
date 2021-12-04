using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeSearch.Core.Entities
{
    public class Channel : BaseClass
    {
        public string YoutubeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }
        public DateTime DateUploaded { get; set; }
    }
}
