using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeSearch.Application.Queries
{
    public class GetVideoNameRequest
    {
        public string Name { get; set; }

        public GetVideoNameRequest(string name)
        {
            Name = name;
        }
    }
}
