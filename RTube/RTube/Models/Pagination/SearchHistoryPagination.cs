using System;
using System.Collections.Generic;
using System.Linq;

namespace RTube.Models.Pagination
{
    public static class SearchHistoryExtensions
    {
        public static PagedSearchHistory ToPagedSearchHistory(this IQueryable<YouTubeItem> query, SearchHistoryPagination pagination)
        {
            var totalItens = query.Count();
            var pagesTotal = (int)Math.Ceiling(totalItens / (decimal)pagination.Size);

            return new PagedSearchHistory
            {
                Total = totalItens,
                PagesTotal = pagesTotal,
                PageNumber = pagination.Page,
                PageSize = pagination.Size,
                Result = query.Skip(pagination.Size * (pagination.Page - 1)).Take(pagination.Size).ToList(),
                PrevPage = (pagination.Page > 1) ?
                    $"searchhistory?page={pagination.Page - 1}&size={pagination.Size}" : "",
                NextPage = (pagination.Page < pagesTotal) ?
                    $"searchhistory?page={pagination.Page + 1}&size={pagination.Size}" : ""
            };
        }
    }

    public class PagedSearchHistory
    {
        public int Total { get; set; }
        public int PagesTotal { get; set; }
        public int PageSize { get; set; }

        public int PageNumber { get; set; }

        public IList<YouTubeItem> Result { get; set; }

        public string PrevPage { get; set; }

        public string NextPage { get; set; }

    }

    public class SearchHistoryPagination
    {
        public int Size { get; set; } = 10;
        public int Page { get; set; } = 1;
    }
}
