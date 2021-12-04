using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YouTubeSearch.Common.Enum;

namespace YoutTubeSearch.API.Models.Requests
{
    public class SearchRequestPaginated : PaginatedRequest
    {
        public string Name { get; set; }
        public TypeEnum? Type { get; set; }
    }
}
