using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace appcore.Models.Result
{
    public class YTResult
    {
        public YTResult(YTResultAPI apiRes)
        {
            NextPageToken = apiRes.nextPageToken;
            PrevPageToken = apiRes.prevPageToken;

            Items = apiRes.items.Select(i => new YoutubeModel(i));
        }

        public IEnumerable<YoutubeModel> Items { get; set; }

        public string NextPageToken { get; set; }

        public string PrevPageToken { get; set; }
    }
}
