using System.Collections.Generic;

namespace YoutubeTree.Application
{
    public class PagedSearchResponse<TResponse>
    {
        public IEnumerable<TResponse> Data { get; set; }
        public string NextPageToken { get; set; }
    }
}