using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeSearch.Application.Responses
{
    public class PaginatedChannelResponse : PaginatedResponse
    {
        public List<ChannelResponse> Channels { get; set; }

        public PaginatedChannelResponse()
        {
            Channels = new List<ChannelResponse>();
        }
    }
}
