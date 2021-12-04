﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeSearch.Application.Responses
{
    public class SearchPaginatedReponse
    {
        public List<SearchResponse> Results { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int Total { get; set; }

        public SearchPaginatedReponse()
        {
            Results = new List<SearchResponse>();
        }
    }
}
