using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeSearch.Application.Queries
{
    public class PaginatedQuery
    {
        public int Page { get; set; }
        public int PageSize { get; set; }

        public PaginatedQuery()
        {
            Page = 1;
            PageSize = 10;
        }

        public PaginatedQuery(int page, int perPage)
        {
            Page = page > 0 ? page : 1;
            PageSize = perPage > 0 ? perPage : 10;
        }
    }
}
