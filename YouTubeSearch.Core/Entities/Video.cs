using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeSearch.Core.Entities
{
    public class Video : BaseClass
    {
        public string YoutubeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Thumb { get; set; }
        public string ChannelId { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
