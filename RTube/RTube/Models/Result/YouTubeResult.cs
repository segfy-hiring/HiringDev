
using System.Collections.Generic;
using System.Linq;

namespace RTube.Models.Result
{
    public class YouTubeResult
    {

        public YouTubeResult(YouTubeApiResult apiResult)
        {
            NextPageToken = apiResult.nextPageToken;
            PrevPageToken = apiResult.prevPageToken;

            Items = apiResult.items.Select(i => new YouTubeItem(i));
        }

        public IEnumerable<YouTubeItem> Items { get; set; }

        public string NextPageToken { get; set; }

        public string PrevPageToken { get; set; }
    }
}
