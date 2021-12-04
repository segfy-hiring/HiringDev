using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeSearch.Application.Responses;
using YouTubeSearch.Common.Enum;

namespace YouTubeSearch.Application.Queries
{
    public class GetSearchResultFilteredRequest : IRequest<SearchPaginatedReponse>
    {
        public string Name { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public TypeEnum? Type { get; set; }
    }
}
