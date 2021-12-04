using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeSearch.Application.Responses
{
    public class PaginatedVideoResponse : PaginatedResponse
    {
        public List<VideoResponse> Videos { get; set; }

        public PaginatedVideoResponse()
        {
            Videos = new List<VideoResponse>();
        }
    }
}
