using RTube.Models;
using RTube.Models.Pagination;
using RTube.Models.Result;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RTube.Services
{
    public interface IYouTubeService
    {
        Task<YouTubeResult> Search(string query, string pageToken = null);

        PagedSearchHistory GetSearchHistory(SearchHistoryPagination pagination);
    }
}