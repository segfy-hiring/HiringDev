using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YoutTubeSearch.API.Models.Requests
{
    public class PaginatedRequest
    {
        public int Page { get; set; }
        public int PageSize { get; set; }

        public PaginatedRequest()
        {
            Page = 1;
            PageSize = 10;
        }

        public PaginatedRequest(int page, int perPage)
        {
            Page = page > 0 ? page : 1;
            PageSize = perPage > 0 ? perPage : 10;
        }
    }
}
