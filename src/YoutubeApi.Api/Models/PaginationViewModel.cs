using System.Collections.Generic;

namespace YoutubeApi.Api.Models
{
    public class PaginationViewModel
    {
        public string Search { get; set; }

        public string NextPage { get; set; }

        public List<SearchViewModel> Searches { get; set; }
    }
}
